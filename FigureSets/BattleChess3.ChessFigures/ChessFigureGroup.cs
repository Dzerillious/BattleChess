using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.ChessFigures;

public class ChessFigureGroup : IFigureGroup
{
    public string ShownName => CurrentLocalization.Instance["ChessFigureGroup_Name"];

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
