using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.ChessFigures
{
    public class Tower : IFigureType
    {
        public static readonly Tower Instance = new Tower();
        public string ShownName => "Tower";
        public string UnitName => "Chess_Tower";
        public string GroupName => "Chess";
        public FigureType UnitType => FigureType.Object;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 5;
        public string Description => "\nRook\n\nA rook (/rʊk/; ♖,♜) is a piece in the strategy board game of chess. Formerly the piece was called the tower, marquess, rector, and comes (Sunnucks 1970). The term castle is considered informal, incorrect, or old-fashioned. Each player starts the game with two rooks, one on each of the corner squares on their own side of the board.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}