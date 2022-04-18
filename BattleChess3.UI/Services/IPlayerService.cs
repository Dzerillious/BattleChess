using BattleChess3.Core.Model;

namespace BattleChess3.UI.Services
{
    public interface IPlayerService
    {
        /// <summary>
        /// Gets current player.
        /// </summary>
        Player CurrentPlayer { get; }

        /// <summary>
        /// Gets player with id.
        /// </summary>
        Player GetPlayer(int id);

        /// <summary>
        /// Initialize players.
        /// </summary>
        void InitializePlayers(in int playersCount, in int currentPlayer);

        /// <summary>
        /// Sets next player as <see cref="CurrentPlayer"/>.
        /// </summary>
        void NextTurn();
    }
}
