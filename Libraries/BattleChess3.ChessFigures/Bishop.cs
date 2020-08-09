using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.ChessFigures
{
    public class Bishop : IFigureType
    {
        public string ShownName => "Bishop";
        public string UnitName => "Chess_Bishop";
        public string GroupName => "Chess";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;
        public string Description => "\nBishop\n\nA bishop (♗,♝) is a piece in the board game of chess. Each player begins the game with two bishops. One starts between the king's knight and the king, the other between the queen's knight and the queen. The starting squares are c1 and f1 for White's bishops, and c8 and f8 for Black's bishops.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}