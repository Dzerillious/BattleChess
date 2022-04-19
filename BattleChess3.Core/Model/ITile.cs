using BattleChess3.Core.Model.Figures;

namespace BattleChess3.Core.Model;

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
    /// ToString for debugging
    /// </summary>
    /// <returns></returns>
    string ToString() => $"{Position}:{Figure}";
}
