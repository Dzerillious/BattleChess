using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes.ClassicChess
{
    public class ChessTower : DirectionAttack, IFigure
    {
        public string UnitName => Resource.ChessTower;
        public string UnitType => Resource.Object;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 5;
        public string Description => "Chess tower is movable unit which can defend quite large area.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\ClassicChess\\ChessTowerBlack.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\ClassicChess\\ChessTowerWhite.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoveDirections =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
        };

        private readonly Position[] _avaibleAttackDirections =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
        };

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, bool> CanMove => (figure, moveToFigure) =>
              CanMoveDirection(figure, moveToFigure, _avaibleMoveDirections);

        public Func<BaseFigure, BaseFigure, bool> CanAttack => (figure, attackFigure) =>
              CanAttackDirection(figure, attackFigure, _avaibleAttackDirections);
    }
}