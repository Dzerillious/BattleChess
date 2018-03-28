using BattleChess3.Shared;
using BattleChess3.Shared.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes
{
    public class Nothing : IFigure
    {
        public string UnitName => Resource.Nothing;
        public string UnitType => Resource.Neutral;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 0;
        public int Defence => 1000;
        public bool MovingWhileAttacking => false;
        public string Description => "Empty tile, where you can go";
        public string PictureBlackPath => "";
        public string PictureWhitePath => "";
        public string PictureNeutralPath => Directory.GetCurrentDirectory() + "\\Pictures\\Nothing.png";
        public int Cost => 0;
        public Position[] AttackPattern => null;
        public Func<BaseFigure, BaseFigure, bool> CanMove => (figure, moveToFigure) => false;
        public Func<BaseFigure, BaseFigure, bool> CanAttack => (figure, attackFigure) => false;
    }
}