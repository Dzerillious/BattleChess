using System;
using BattleChess3.Figures.AttackingTypes;
using BattleChess3.Properties;

namespace BattleChess3.Figures.FigureTypes
{
    public class ChessQueen : DirectionAttack, IFigure
    {
        public string UnitName => Resource.ChessQueen;
        public string UnitType => Resource.Special;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public bool LongRanged => true;
        public int Cost => 1;
        public string Description => "Chess queen";

        public string PictureBlackPath => "ChessQueenBlack.png";
        public string PictureWhitePath => "ChessQueenWhite.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoveDirections =
        {
            new Position(0, 1), 
            new Position(0, -1), 
            new Position(1, 0), 
            new Position(-1, 0), 
            new Position(1, 1), 
            new Position(-1, -1),
            new Position(1, -1), 
            new Position(-1, 1), 
        };

        private readonly Position[] _avaibleAttackDirections =
        {
            new Position(0, 1), 
            new Position(0, -1), 
            new Position(1, 0), 
            new Position(-1, 0), 
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