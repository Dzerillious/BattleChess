using System;
using BattleChess3.Properties;

namespace BattleChess3.Figures.FigureTypes
{
    public class Palm : IFigure
    {
        public string UnitName => Resource.Palm;
        public string UnitType => Resource.Neutral;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 0;
        public int Defence => -50;
        public bool MovingWhileAttacking => false;
        public string Description => "Palm tile, which you can easily destroy";
        public string PictureBlackPath => "";
        public string PictureWhitePath => "";
        public string PictureNeutralPath => "Palm.png";
        public int Cost => 0;
        public Position[] AttackPattern => null;
        public Func<BaseFigure, BaseFigure, bool> CanMove => (figure, moveToFigure) => false;
        public Func<BaseFigure, BaseFigure, bool> CanAttack => (figure, attackFigure) => false;
    }
}