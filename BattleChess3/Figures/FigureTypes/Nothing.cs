using System;
using BattleChess3.Properties;

namespace BattleChess3.Figures.FigureTypes
{
    public class Nothing : IFigure
    {
        public string UnitName => Resources.NoObject;
        public string UnitType => null;
        public string Bonus => null;
        public string AntiBonus => null;
        public int Attack => 0;
        public int Defence => 0;
        public bool MovingWhileAttacking => false;
        public bool LongRanged => false;
        public string Description => "";
        public int Cost => 0;
        public Func<Position, Position, bool> CanMove => null;
        public Func<Position, Position, bool> CanAttack => null;
    }
}
