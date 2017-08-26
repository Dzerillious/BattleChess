using System;
using BattleChess3.Properties;

namespace BattleChess3.Figures.FigureTypes
{
    public class Stone : IFigure
    {
        public string UnitName => Resource.Stone;
        public string UnitType => Resource.Neutral;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 0;
        public int Defence => 1000;
        public bool MovingWhileAttacking => false;
        public bool LongRanged => false;
        public string Description => "Stone tile, where you cannot go";
        public string PictureBlackPath => "";
        public string PictureWhitePath => "";
        public string PictureNeutralPath => "Stone.png";
        public int Cost => 0;
        public Position[] AttackPattern => null;
        public Func<BaseFigure, BaseFigure, bool> CanMove => (figure, moveToFigure) => false;
        public Func<BaseFigure, BaseFigure, bool> CanAttack => (figure, attackFigure) => false;
    }
}