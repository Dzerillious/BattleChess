using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.ChessFigures
{
    public class Pawn : IFigureType
    {
        public static readonly Pawn Instance = new Pawn();
        public string ShownName => "Pawn";
        public string UnitName => "Chess_Pawn";
        public string GroupName => "Chess";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 1;
        public string Description => "\nPawn\n\nThe pawn (♙,♟) is the most numerous piece in the game of chess, and in most circumstances, also the weakest. It historically represents infantry, or more particularly, armed peasants or pikemen. Each player begins a game with eight pawns, one on each square of the rank immediately in front of the other pieces. (The white pawns start on a2, b2, c2, ..., h2; the black pawns start on a7, b7, c7, ..., h7.). Individual pawns are referred to by the file on which they stand.For example, one speaks of \"White's f-pawn\" or \"Black's b-pawn\", or less commonly (using descriptive notation), \"White's king bishop pawn\" or \"Black's queen knight pawn\". It is also common to refer to a rook pawn, meaning any pawn on the a- or h-files, a knight pawn(on the b- or g-files), a bishop pawn(on the c- or f-file), a queen pawn(on the d-file), a king pawn(on the e-file), and a central pawn(on the d- or e-files).";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}