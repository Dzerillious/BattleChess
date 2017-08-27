using System;
using BattleChess3.Figures.AttackingTypes;
using BattleChess3.Properties;

namespace BattleChess3.Figures.FigureTypes
{
    public class ChessKing : SimpleAttackFigure, IFigure
    {
        public string UnitName => Resource.ChessKing;
        public string UnitType => Resource.Special;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 0;
        public string Description => "Chess king is quite weak unit and when he is killed, player with him loses. He is stronger than pawn, but you must care about him.";

        public string PictureBlackPath => "ChessKingBlack.png";
        public string PictureWhitePath => "ChessKingWhite.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoves =
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

        private readonly Position[] _avaibleAttacks =
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
            CanMoveSimple(figure, moveToFigure, _avaibleMoves);
        public Func<BaseFigure, BaseFigure, bool> CanAttack => (figure, attackFigure) =>
            CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}