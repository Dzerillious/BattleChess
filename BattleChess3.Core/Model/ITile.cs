using BattleChess3.Core.Model.Figures;

namespace BattleChess3.Core.Model
{
    public interface ITile
    {
        /// <summary>
        /// Position of tile in board
        /// </summary>
        Position Position { get; }
        
        /// <summary>
        /// Current figure on tile
        /// </summary>
        Figure Figure { get; set; }

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

        /// <summary>
        /// ToString for debugging
        /// </summary>
        /// <returns></returns>
        string ToString() => $"{Position}:{Figure}";
    }
}