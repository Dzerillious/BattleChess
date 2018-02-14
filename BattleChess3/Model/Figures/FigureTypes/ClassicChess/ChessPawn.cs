using System;
using System.IO;
using BattleChess3.GameData.Figures.AttackingTypes;
using BattleChess3.Properties;

namespace BattleChess3.GameData.Figures.FigureTypes.ClassicChess
{
    public class ChessPawn : SimpleFrontAttackFigure, IFigure
    {
        public string UnitName => Resource.ChessPawn;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 1;
        public string Description => "Chess pawn is one of cheapest units of game, so he is good for front line attacks. Many of pawns in one big formation.";

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

        public Position[] AttackPattern => new []
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, bool> CanMove => (figure, moveToFigure) =>
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
        public Func<BaseFigure, BaseFigure, bool> CanAttack => (figure, attackFigure) =>
            CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}