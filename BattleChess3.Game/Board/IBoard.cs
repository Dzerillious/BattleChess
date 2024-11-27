namespace BattleChess3.Game.Board;

public interface IBoard : IReadOnlyList<ITile>
{
    public const int Length = 8;
    public const int TilesCount = 64;
    
    ITile this[Position position] { get; }
    
    ITile this[int x, int y] { get; }
    
    bool TryGetTile(Position position, out ITile tile);
    
    bool TryGetTile(int x, int y, out ITile tile);
}