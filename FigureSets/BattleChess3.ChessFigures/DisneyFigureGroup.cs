using BattleChess3.DisneyFigures.Localization;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.DisneyFigures;

public class DisneyFigureGroup : IFigureGroup
{
    public string ShownName => CurrentLocalization.Instance[$"{nameof(DisneyFigureGroup)}_Name"];

    public IFigureType[] FigureTypes => new IFigureType[]
    {
        King.Instance,
        Queen.Instance,
        Rook.Instance,
        Bishop.Instance,
        Knight.Instance,
        Pawn.Instance,
    };
}
