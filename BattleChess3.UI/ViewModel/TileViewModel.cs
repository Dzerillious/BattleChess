using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel;

public class TileViewModel : ViewModelBase, ITileViewModel
{
    public Position Position { get; }

    private bool _isMouseOver;
    public bool IsMouseOver
    {
        get => _isMouseOver;
        set => Set(ref _isMouseOver, value);
    }

    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set => Set(ref _isSelected, value);
    }

    private bool _isPossibleMove;
    public bool IsPossibleMove
    {
        get => _isPossibleMove;
        set => Set(ref _isPossibleMove, value);
    }

    private bool _isPossibleAction;
    public bool IsPossibleAttack
    {
        get => _isPossibleAction;
        set => Set(ref _isPossibleAction, value);
    }

    private Figure _figure = Figure.None;
    public Figure Figure
    {
        get => _figure;
        set => Set(ref _figure, value);
    }

    public TileViewModel(Position position)
    {
        Position = position;
    }

    public ITile GetPovTile(Player player)
        => new PlayedTile(this, player);
}
