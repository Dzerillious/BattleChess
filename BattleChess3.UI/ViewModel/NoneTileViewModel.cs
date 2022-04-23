using BattleChess3.Core.Model.Figures;
using BattleChess3.UI.ViewModel;

namespace BattleChess3.Core.Model;

public class NoneTileViewModel : ITileViewModel
{
    public static readonly NoneTileViewModel Instance = new();
    
    public Position Position { get; } = Position.None;
    public Figure Figure { get; set; } = Figure.None;
    public bool IsMouseOver { get; set; }
    public bool IsSelected { get; set; }
    public bool IsPossibleMove { get; set; }
    public bool IsPossibleAttack { get; set; }
    public ITile GetPovTile(Player player) => this;
}
