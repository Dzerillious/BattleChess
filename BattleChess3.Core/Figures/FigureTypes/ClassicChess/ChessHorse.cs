using System;

namespace BattleChess3.Core.Figures.FigureTypes.ClassicChess
{
    public class ChessHorse : IFigure
    {
        public string ShownName => "Knight";
        public string UnitName => "ChessHorse";
        public string GroupName => "Chess";
        public FigureType UnitType => FigureType.Mount;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;
        public string Description => "\nKnight\n\nThe knight (♘ ♞ /naɪt/) is a piece in the game of chess, representing a knight (armored cavalry). It is normally represented by a horse's head and neck. Each player starts with two knights, which begin on the row closest to the player, between the rooks and bishops.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}