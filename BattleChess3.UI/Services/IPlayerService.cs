using BattleChess3.Core.Model;

namespace BattleChess3.UI.Services
{
    public interface IPlayerService
    {
        /// <summary>
        /// Gets players count.
        /// </summary>
        int PlayersCount { get; }

        /// <summary>
        /// Gets current player.
        /// </summary>
        Player CurrentPlayer { get; }

        /// <summary>
        /// Gets player with id.
        /// </summary>
        Player GetPlayer(int id);

        /// <summary>
        /// Set current players.
        /// </summary>
        void InitializePlayers(in int currentPlayer);

        /// <summary>
        /// Sets next player as <see cref="CurrentPlayer"/>.
        /// </summary>
        void NextTurn();
    }
}
