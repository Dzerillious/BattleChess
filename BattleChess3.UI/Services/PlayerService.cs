using System.Collections.Generic;
using System.Linq;
using BattleChess3.Core.Model;

namespace BattleChess3.UI.Services;

public class PlayerService : IPlayerService
{
    private readonly List<Player> _players = new List<Player>();

    public int PlayersCount => _players.Count - 1;
    public Player CurrentPlayer { get; private set; } = Player.Neutral;
    public Player GetPlayer(int id) => _players[id];

    public void InitializePlayers(in int playersCount, in int currentPlayerId)
    {
        _players.Clear();
        for (int i = 0; i <= playersCount; i++)
            _players.Add(new Player(i));

        var currentPlayer = currentPlayerId;
        CurrentPlayer = _players.First(x => x.Id == currentPlayer);
    }

    public void NextTurn()
    {
        int nextId = (CurrentPlayer.Id + 1) % _players.Count;
        if (nextId == 0)
            nextId = 1;

        CurrentPlayer = GetPlayer(nextId);
    }
}
