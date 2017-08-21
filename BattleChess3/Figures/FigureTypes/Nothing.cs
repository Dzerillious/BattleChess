using System;
using BattleChess3.Properties;

namespace BattleChess3.Figures.FigureTypes
{
    public class Nothing : IFigure
    {
        public string UnitName => Resource.Nothing;
        public string UnitType => null;
        public string Bonus => null;
        public string AntiBonus => null;
        public int Attack => 0;
        public int Defence => 1000;
        public bool MovingWhileAttacking => false;
        public bool LongRanged => false;
        public string Description => "";
        public string PictureBlackPath => "";
        public string PictureWhitePath => "";
        public string PictureNeutralPath => "Nothing.png";
        public int Cost => 0;
        public Func<Position, Position, bool> CanMove => (figurePosition, movedPosition) => false;
        public Func<Position, Position, bool> CanAttack => (figurePosition, movedPosition) => false;
    }
}
