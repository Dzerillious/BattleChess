using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Default
{
    public class Stone : IFigure
    {
        public string ShownName => "Stone";
        public string UnitName => "Stone";
        public FigureType UnitType => FigureType.Object;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 0;
        public int Defence => 1000;
        public bool MovingWhileAttacking => false;
        public string Description => "Stone tile, where you cannot go. It cannot move and belongs to no one";
        public string PictureBlackPath => "";
        public string PictureWhitePath => "";
        public string PictureNeutralPath => Directory.GetCurrentDirectory() + "\\Pictures\\Stone.png";
        public int Cost => 0;
        public Position[] AttackPattern => null;
        public Func<Figure, Figure, Func<Position, Figure>, bool> CanMove => (figure, moveToFigure, x) => false;
        public Func<Figure, Figure, Func<Position, Figure>, bool> CanAttack => (figure, attackFigure, x) => false;
    }
}