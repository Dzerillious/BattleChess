using System.Collections.Generic;
using BattleChess3.Core.Model;

namespace BattleChess3.UI.Services;

public class PlayerService : IPlayerService
{
    private readonly List<Player> _players = new List<Player>();
    
    public Player CurrentPlayer { get; private set; } = Player.Neutral;
    public Player GetPlayer(int id) => _players[id + 1];

    public void InitializePlayers(in int playersCount, in int currentPlayer)
    {
        _players.Clear();
        for (int i = -1; i < playersCount; i++)
            _players.Add(new Player(i));
        CurrentPlayer = GetPlayer(currentPlayer);
    }

    public void NextTurn()
    {
        int nextId = (CurrentPlayer.Id + 1) % (_players.Count - 1);
        CurrentPlayer = GetPlayer(nextId);
    }
}
