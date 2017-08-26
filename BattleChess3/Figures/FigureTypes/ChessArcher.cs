using System;
using BattleChess3.Figures.AttackingTypes;
using BattleChess3.Properties;

namespace BattleChess3.Figures.FigureTypes
{
    public class ChessArcher : DirectionAttack, IFigure
    {
        public string UnitName => Resource.ChessArcher;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public bool LongRanged => true;
        public int Cost => 1;
        public string Description => "Chess archer";

        public string PictureBlackPath => "ChessArcherBlack.png";
        public string PictureWhitePath => "ChessArcherWhite.png";
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

        public Position[] AttackPattern => new []
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, bool> CanMove => (figure, moveToFigure) =>
            CanMoveDirection(figure, moveToFigure, _avaibleMoveDirections);
        public Func<BaseFigure, BaseFigure, bool> CanAttack => (figure, attackFigure) =>
            CanAttackDirection(figure, attackFigure, _avaibleAttackDirections);
    }
}