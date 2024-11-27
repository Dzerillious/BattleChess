using System.Diagnostics.CodeAnalysis;

namespace BattleChess3.Multiplayer.Messaging;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
internal abstract class ChannelPost
{
    public long message_id { get; set; }
    public object? sender_chat { get; set; }
    public object? chat { get; set; }
    public long date { get; set; }
    public string? text { get; set; }
}