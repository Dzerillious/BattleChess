using BattleChess3.Game.Figures;
using BattleChess3.Game.Players;

namespace BattleChess3.Game.Board;

public class NoneTile : ITile
{
    public static readonly ITile Instance = new NoneTile();
    
    public Position Position { get; } = new Position();
    public Position AbsolutePosition { get; } = new Position();
    public Figure Figure { get; set; } = Figure.None;
    
    public ITile GetPovTile(Player player)
    {
        return Instance;
    }
}