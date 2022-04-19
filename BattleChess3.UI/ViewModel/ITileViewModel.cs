using BattleChess3.Core.Model;

namespace BattleChess3.UI.ViewModel
{
    /// <summary>
    /// Interface for view model of tile.
    /// </summary>
    public interface ITileViewModel : ITile
    {

        /// <summary>
        /// Gets if mouse is over tile
        /// </summary>
        bool IsMouseOver { get; set; }

        /// <summary>
        /// Gets if tile is selected
        /// </summary>
        bool IsSelected { get; set; }

        /// <summary>
        /// Gets if is possible to move at this tile
        /// </summary>
        bool IsPossibleMove { get; set; }

        /// <summary>
        /// Gets if is possible to attack this tile
        /// </summary>
        bool IsPossibleAttack { get; set; }
    }
}
