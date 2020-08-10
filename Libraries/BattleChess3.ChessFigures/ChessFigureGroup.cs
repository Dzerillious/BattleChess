﻿using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Figures;

namespace BattleChess3.ChessFigures
{
    public class ChessFigureGroup : IFigureGroup
    {
        public string ShownName => CurrentLocalization.Instance["ChessFigureGroup_Name"];

        public IFigureType[] GroupFigures => new IFigureType[]
        {
            King.Instance,
            Queen.Instance,
            Rook.Instance,
            Bishop.Instance,
            Knight.Instance,
            Pawn.Instance,
        };
    }
}
