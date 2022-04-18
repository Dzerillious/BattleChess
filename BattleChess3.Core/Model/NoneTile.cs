using BattleChess3.Core.Model.Figures;

namespace BattleChess3.Core.Model;

public class NoneTile : ITile
{
    public static readonly NoneTile Instance = new();
    
    public Position Position { get; } = Position.None;
    public Figure Figure { get; set; } = Figure.None;
    public bool IsMouseOver { get; set; }
    public bool IsSelected { get; set; }
    public bool IsPossibleMove { get; set; }
    public bool IsPossibleAttack { get; set; }
}
