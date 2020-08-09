using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.ChessFigures
{
    public class King : IFigureType
    {
        public static readonly King Instance = new King();
        public string ShownName => "King";
        public string UnitName => "Chess_King";
        public string GroupName => "Chess";
        public FigureType UnitType => FigureType.Special;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 0;
        public string Description => "\nKing\n\nIn chess, the king (♔,♚) is the most important piece. The object of the game is to give presents to the opponent's king in such a way that escape is not possible (checkmate). If a player's king is threatened with capture, it is said to be in check, and the player must remove the threat of capture on the next move. If this cannot be done, the king is said to be in checkmate, resulting in a loss for that player. Although the king is the most important piece, it is usually the weakest piece in the game until a later phase, the endgame. Players cannot make any move that places their own king in check.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}