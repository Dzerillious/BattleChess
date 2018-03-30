using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Model.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes.ClassicChess
{
    public class ChessPawn : SimpleFrontAttackFigure, IFigure
    {
        public string ShownName => "Pawn";
        public string UnitName => "ChessPawn";
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 1;
        public string Description => "\nPawn\n\nThe pawn (♙,♟) is the most numerous piece in the game of chess, and in most circumstances, also the weakest. It historically represents infantry, or more particularly, armed peasants or pikemen. Each player begins a game with eight pawns, one on each square of the rank immediately in front of the other pieces. (The white pawns start on a2, b2, c2, ..., h2; the black pawns start on a7, b7, c7, ..., h7.). Individual pawns are referred to by the file on which they stand.For example, one speaks of \"White's f-pawn\" or \"Black's b-pawn\", or less commonly (using descriptive notation), \"White's king bishop pawn\" or \"Black's queen knight pawn\". It is also common to refer to a rook pawn, meaning any pawn on the a- or h-files, a knight pawn(on the b- or g-files), a bishop pawn(on the c- or f-file), a queen pawn(on the d-file), a king pawn(on the e-file), and a central pawn(on the d- or e-files).";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\ClassicChess\\ChessPawnBlack.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\ClassicChess\\ChessPawnWhite.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleFirstMoves =
        {
            new Position(0, 1),
            new Position(0, 2),
            new Position(0, -1),
            new Position(0, -2),
        };

        private readonly Position[] _avaibleMoves =
        {
            new Position(0, 1),
            new Position(0, -1),
        };

        private readonly Position[] _avaibleAttacks =
        {
            new Position(1, 1),
            new Position(-1, -1),
            new Position(-1, 1),
            new Position(1, -1),
        };

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanMove => (figure, moveToFigure, x) =>
        {
            if (figure.Position.Y == 1 || figure.Position.Y == 6)
            {
                return CanMoveSimple(figure, moveToFigure, _avaibleFirstMoves);
            }
            else
            {
                return CanMoveSimple(figure, moveToFigure, _avaibleMoves);
            }
        };

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanAttack => (figure, attackFigure, x) =>
                 CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}