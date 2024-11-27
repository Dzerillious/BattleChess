using BattleChess3.Game.Figures;

namespace BattleChess3.UI.ViewModel;

public sealed class FigureGroupViewModel : IFigureGroup
{
    public FigureGroupViewModel(IFigureGroup figureGroup)
    {
        DisplayName = figureGroup.DisplayName;
        FigureTypes = figureGroup.FigureTypes
            .Select(x => new FigureViewModel(x))
            .Cast<IFigureType>()
            .ToArray();
    }

    public string DisplayName { get; }
    public IFigureType[] FigureTypes { get; }
}