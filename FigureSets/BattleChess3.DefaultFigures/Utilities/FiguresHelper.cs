﻿using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.DefaultFigures.Utilities;

public static class FiguresHelper
{
    public static bool IsEmpty(this ITile figureType)
        => figureType.Figure.UnitName == Empty.Instance.UnitName;

    public static bool IsWater(this ITile figureType)
        => figureType.Figure.UnitName == Water.Instance.UnitName;
}
