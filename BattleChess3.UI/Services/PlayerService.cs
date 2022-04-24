using System.Collections.Generic;
using BattleChess3.Core.Model;

namespace BattleChess3.UI.Services;

public class PlayerService : IPlayerService
{
    private readonly IDictionary<int, Player> _players = new Dictionary<int, Player>();
    private int _currentPlayerId = 0;

    public int PlayersCount => _players.Count - 1;

    public Player CurrentPlayer => GetPlayer(_currentPlayerId);
    public Player GetPlayer(int id)
    {
        if (_players.TryGetValue(id, out var player))
        {
            return player;
        }

        _players[id] = new Player(id);
        return _players[id];
    }

    public void InitializePlayers(in int currentPlayerId)
    {
        _players.Clear();
        _currentPlayerId = currentPlayerId;
    }

    public void NextTurn()
    {
        while (true)
        {
            NextPlayer();

            if (CurrentPlayer.Figures.Count > 0)
                break;
        }
    }

    private void NextPlayer()
    {
        _currentPlayerId = (_currentPlayerId + 1) % _players.Count;
        if (_currentPlayerId == 0)
            _currentPlayerId = 1;
    }
}
