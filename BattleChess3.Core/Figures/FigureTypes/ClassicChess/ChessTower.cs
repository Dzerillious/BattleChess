using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.ClassicChess
{
    public class ChessTower : DirectionAttack, IFigure
    {
        public string ShownName => "Tower";
        public string UnitName => "ChessTower";
        public FigureType UnitType => FigureType.Object;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 5;
        public string Description => "\nRook\n\nA rook (/rʊk/; ♖,♜) is a piece in the strategy board game of chess. Formerly the piece was called the tower, marquess, rector, and comes (Sunnucks 1970). The term castle is considered informal, incorrect, or old-fashioned. Each player starts the game with two rooks, one on each of the corner squares on their own side of the board.";

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

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanMove => (figure, moveToFigure, getFigureAtPosition) =>
                 CanMoveDirection(figure, moveToFigure, _avaibleMoveDirections, getFigureAtPosition);

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanAttack => (figure, attackFigure, getFigureAtPosition) =>
                 CanAttackDirection(figure, attackFigure, _avaibleAttackDirections, getFigureAtPosition);
    }
}