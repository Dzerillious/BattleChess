using BattleChess3.Core.Model;
using BattleChess3.Core.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace BattleChess3.UI.Services;

public class MultiplayerService : IMultiplayerService
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly Timer _timer;

    private Queue<MessageWithType> _scheduledMessages = new Queue<MessageWithType>();
    private string _chatId = string.Empty;
    private string _apiKey = string.Empty;
    private string _lastMessage = string.Empty;
    private bool _sendingBlocked;

    public bool IsHost { get; private set; }
    public bool IsGuest { get; private set; }
    public bool IsConnected => IsHost || IsGuest;

    public event EventHandler<Position>? RequestClickTile;
    public event EventHandler<MapBlueprint>? RequestLoadMap;

    public MultiplayerService()
    {
        _timer = new Timer
        {
            AutoReset = true,
            Interval = 1000,
            Enabled = true
        };

        _timer.Elapsed += TimerOnElapsed;
    }

    private readonly Regex regex = new Regex("(.*)(@.*)");

    public void Host(string key, MapBlueprint map, Position selectedPosition)
    {
        if (IsConnected)
            return;

        var matches = regex.Matches(key);
        _apiKey = matches[0].Groups[1].Value;
        _chatId = matches[0].Groups[2].Value;
        _sendingBlocked = false;

        IsHost = true;
        GetUpdatesMessage()
            .ContinueWith(_ =>
            {
                LoadMap(map);
                ClickOnPosition(selectedPosition);
                _timer.Start();
            });
    }

    public void Join(string key)
    {
        if (IsConnected)
            return;

        var matches = regex.Matches(key);
        _apiKey = matches[0].Groups[1].Value;
        _chatId = matches[0].Groups[2].Value;
        _sendingBlocked = false;

        IsGuest = true;
        GetUpdatesMessage()
            .ContinueWith(_ =>
            {
                _timer.Start();
            });
    }

    public void Stop()
    {
        if (!IsConnected)
            return;

        IsHost = false;
        IsGuest = false;
        _timer.Stop();
    }

    public void LoadMap(MapBlueprint map)
    {
        if (!IsConnected)
            return;

        lock (_scheduledMessages)
        {
            _scheduledMessages.Clear();
            _scheduledMessages.Enqueue(new MessageWithType
            {
                message = JsonConvert.SerializeObject(map),
                message_type = nameof(MapBlueprint)
            });
        }
    }

    public void ClickOnPosition(Position position)
    {
        if (!IsConnected)
            return;

        lock (_scheduledMessages)
        {
            _scheduledMessages.Enqueue(new MessageWithType
            {
                message = JsonConvert.SerializeObject(position),
                message_type = nameof(Position),
            });
        }
    }

    public void ConfirmReceive()
    {
        if (!IsConnected)
            return;

        lock (_scheduledMessages)
        {
            _scheduledMessages.Enqueue(new MessageWithType
            {
                message_type = nameof(Confirm),
            });
        }
    }

    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        if (!IsConnected)
            return;

        var messages = Array.Empty<MessageWithType>();
        lock (_scheduledMessages)
        {
            if (_scheduledMessages.Count > 0 && !_sendingBlocked)
            {
                _sendingBlocked = true;
                messages = _scheduledMessages.ToArray();
                _scheduledMessages.Clear();
            }
        }

        if (messages.Length > 0)
        {
            SendMessage(messages);
        }
        else
        {
            GetUpdatesMessage();
        }
    }

    private Task SendMessage(MessageWithType[] messages)
    {
        if (!IsConnected)
            return Task.CompletedTask;

        var serializedMessage = JsonConvert.SerializeObject(messages);
        var compressed = CompressionHelper.Compress(serializedMessage);
        var request = $"https://api.telegram.org/bot{_apiKey}/sendMessage?chat_id={_chatId}&text={compressed}";

        return _httpClient.GetAsync(request)
            .ContinueWith(x =>
            {
                if (x.IsFaulted || !x.Result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Failed to send data.");
                }
            });
    }

    private Task GetUpdatesMessage()
    {
        if (!IsConnected)
            return Task.CompletedTask;

        var request = $"https://api.telegram.org/bot{_apiKey}/getUpdates?chat_id={_chatId}&offset={-1}";
        return _httpClient.GetAsync(request)
            .ContinueWith(async x =>
            {
                try
                {
                    if (x.IsFaulted || !x.Result.IsSuccessStatusCode)
                        MessageBox.Show("Failed to recieve remote data.");

                    var stringContent = await x.Result.Content.ReadAsStringAsync();
                    if (_lastMessage == stringContent)
                        return;

                    _lastMessage = stringContent;
                    var content = JsonConvert.DeserializeObject<Root>(stringContent);
                    var text = content.result[0]?.channel_post?.text;
                    if (string.IsNullOrEmpty(text))
                        return;

                    var messageText = CompressionHelper.Decompress(text);
                    var messagesWithType = JsonConvert.DeserializeObject<MessageWithType[]>(messageText);

                    foreach (var item in messagesWithType)
                        HandleMessage(item);
                    ConfirmReceive();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Failed to process remote data.");
                    throw;
                }
            });
    }

    private void HandleMessage(MessageWithType messageWithType)
    {
        if (messageWithType.message_type == nameof(Position))
        {
            var position = JsonConvert.DeserializeObject<Position>(messageWithType.message);
            Application.Current.Dispatcher.Invoke(() => RequestClickTile?.Invoke(this, position));
        }
        else if (messageWithType.message_type == nameof(MapBlueprint))
        {
            var mapBlueprint = JsonConvert.DeserializeObject<MapBlueprint>(messageWithType.message);
            Application.Current.Dispatcher.Invoke(() => RequestLoadMap?.Invoke(this, mapBlueprint));
        }
        else if (messageWithType.message_type == nameof(Confirm))
        {
            _sendingBlocked = false;
        }
    }

    public class Confirm { }

    public class MessageWithType
    {
        public string message_type { get; set; }
        public string message { get; set; }
    }

    public class ChannelPost
    {
        public long message_id { get; set; }
        public object sender_chat { get; set; }
        public object chat { get; set; }
        public long date { get; set; }
        public string text { get; set; }
    }

    public class RequestResult
    {
        public long update_id { get; set; }
        public ChannelPost channel_post { get; set; }
    }

    public class Root
    {
        public bool ok { get; set; }
        public List<RequestResult> result { get; set; }
    }
}
