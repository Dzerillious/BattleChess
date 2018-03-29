using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Shared;
using BattleChess3.Shared.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes.Hobbit
{
    public class HobbitHelper : DirectionAttack, IFigure
    {
        public string ShownName => "Helper";
        public string UnitName => Resource.HobbitHelper;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 3;
        public string Description => "";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Felgrom.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Ori.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoveDirections =
        {
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
        };

        private readonly Position[] _avaibleAttackDirections =
        {
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
        };

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanMove => (figure, moveToFigure, getFigureAtPosition) =>
                CanMoveDirection(figure, moveToFigure, _avaibleMoveDirections, getFigureAtPosition);

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanAttack => (figure, attackFigure, getFigureAtPosition) =>
                CanAttackDirection(figure, attackFigure, _avaibleAttackDirections, getFigureAtPosition);
    }
}