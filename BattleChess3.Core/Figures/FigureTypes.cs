using System;

namespace BattleChess3.Core.Figures
{
    [Flags]
    public enum FigureTypes
    {
        Nothing = 0,
        Foot = 1,
        Mount = 2,
        Special = 4,
        Object = 8
    }
}