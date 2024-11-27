using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;
using BattleChess3.Game.Players;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel;

public class TileViewModel : ViewModelBase, ITile
{
    private Figure _figure = Figure.None;

    private bool _isMouseOver;

    private bool _isPossibleAttack;

    private bool _isPossibleMove;

    private bool _isPossibleSpecial;

    private bool _isSelected;

    private FigureAction _possibleAction = FigureAction.None;

    public TileViewModel(Position position)
    {
        Position = position;
    }

    public Position Position { get; }
    public Position AbsolutePosition => Position;

    public bool IsMouseOver
    {
        get => _isMouseOver;
        set => Set(ref _isMouseOver, value);
    }

    public bool IsSelected
    {
        get => _isSelected;
        set => Set(ref _isSelected, value);
    }

    public bool IsPossibleAttack
    {
        get => _isPossibleAttack;
        private set => Set(ref _isPossibleAttack, value);
    }

    public bool IsPossibleMove
    {
        get => _isPossibleMove;
        private set => Set(ref _isPossibleMove, value);
    }

    public bool IsPossibleSpecial
    {
        get => _isPossibleSpecial;
        private set => Set(ref _isPossibleSpecial, value);
    }

    public FigureAction PossibleAction
    {
        get => _possibleAction;
        set
        {
            Set(ref _possibleAction, value);
            IsPossibleAttack = value.ActionType == FigureActionTypes.Attack;
            IsPossibleMove = value.ActionType == FigureActionTypes.Move;
            IsPossibleSpecial = value.ActionType == FigureActionTypes.Special;
        }
    }

    public Figure Figure
    {
        get => _figure;
        set => Set(ref _figure, value);
    }

    public ITile GetPovTile(Player player)
    {
        return new PovTile(this, player);
    }
}