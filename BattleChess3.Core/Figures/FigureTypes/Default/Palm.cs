using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Default
{
    public class Palm : IFigure
    {
        public string ShownName => "Palm";
        public string UnitName => "Palm";
        public FigureType UnitType => FigureType.Object;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 0;
        public int Defence => -50;
        public bool MovingWhileAttacking => false;
        public string Description => "Palm tile, which you can easily destroy. It cannot move and belongs to no one";
        public string PictureBlackPath => "";
        public string PictureWhitePath => "";
        public string PictureNeutralPath => Directory.GetCurrentDirectory() + "\\Pictures\\Palm.png";
        public int Cost => 0;
        public Position[] AttackPattern => null;
        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanMove => (figure, moveToFigure, x) => false;
        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanAttack => (figure, attackFigure, x) => false;
    }
}