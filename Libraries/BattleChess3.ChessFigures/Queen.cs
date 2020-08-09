using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.ChessFigures
{
    public class Queen : IFigureType
    {
        public static readonly Queen Instance = new Queen();
        public string ShownName => "Queen";
        public string UnitName => "Chess_Queen";
        public string GroupName => "Chess";
        public FigureType UnitType => FigureType.Special;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 9;
        public string Description => "\nQueen\n\nThe queen (♕,♛) is the most powerful piece in the game of chess, able to move any number of squares vertically, horizontally or diagonally. Each player starts the game with one queen, placed in the middle of the first rank next to the king. Because the queen is the strongest piece, a pawn is promoted to a queen in the vast majority of cases. In the game shatranj, the ancestor of chess that included only male figures, the closest thing to the queen was the “vizier”, a weak piece only able to move or capture one step diagonally and not at all in any other direction.The modern chess queen gained power in the 15th century.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}