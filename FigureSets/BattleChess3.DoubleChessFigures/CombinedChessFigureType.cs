using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.DoubleChessFigures.Localization;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.DoubleChessFigures;

public class CombinedChessFigureType<T1, T2> : IFigureType
    where T1 : IFigureType, new()
    where T2 : IFigureType, new()
{
    private readonly T1 _firstFigure;
    private readonly T2 _secondFigure;
    private readonly string _unitName;

    public CombinedChessFigureType(string unitName)
    {
        _unitName = unitName;
        _firstFigure = new T1();
        _secondFigure = new T2();
    }

    public string UnitName => $"{nameof(DoubleChessFigureGroup)}.{_unitName}";
    public string DisplayName => CurrentLocalization.Instance[$"{_unitName}_Name"];
    public string Description => CurrentLocalization.Instance[$"{_unitName}_{nameof(Description)}"];

    public IDictionary<int, Uri> ImageUris =>
        new Dictionary<int, Uri>
        {
            { 1, new Uri($"pack://application:,,,/BattleChess3.DoubleChessFigures;component/Images/{_unitName}1.png", UriKind.Absolute) },
            { 2, new Uri($"pack://application:,,,/BattleChess3.DoubleChessFigures;component/Images/{_unitName}2.png", UriKind.Absolute) }
        };

    public IEnumerable<FigureAction> GetPossibleActions(ITile unitTile, IBoard board)
    {
        var firstFigureActions = _firstFigure.GetPossibleActions(unitTile, board)
            .Select(x => new FigureAction(
                x.ActionType,
                x.SourcePosition,
                x.TargetPosition, () =>
                {
                    var owner = unitTile.Figure.Owner;
                    unitTile.Die(board);
                    unitTile.CreateFigure(new Figure(owner, _firstFigure), board);
                    x.Action.Invoke();
                    unitTile.CreateFigure(new Figure(owner, _secondFigure), board);
                }));
        
        var secondFigureActions = _secondFigure.GetPossibleActions(unitTile, board)
            .Select(x => new FigureAction(
                x.ActionType,
                x.SourcePosition,
                x.TargetPosition, () =>
                {
                    var owner = unitTile.Figure.Owner;
                    unitTile.Die(board);
                    unitTile.CreateFigure(new Figure(owner, _secondFigure), board);
                    x.Action.Invoke();
                    unitTile.CreateFigure(new Figure(owner, _firstFigure), board);
                }));
            
        return firstFigureActions
            .Concat(secondFigureActions)
            .DistinctBy(x => x.TargetPosition);
    }
}