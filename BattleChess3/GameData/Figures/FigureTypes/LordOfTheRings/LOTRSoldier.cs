using System;
using System.IO;
using BattleChess3.GameData.Figures.AttackingTypes;
using BattleChess3.Properties;

namespace BattleChess3.GameData.Figures.FigureTypes.LordOfTheRings
{
    public class LOTRSoldier : SimpleAttackFigure, IFigure
    {
        public string UnitName => Resource.ChessHorse;
        public string UnitType => Resource.Mount;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 3;

        public string Description =>
            "Chess horse is quite movable unit which can easily suprise enemy, because his attacks are definet by many points, not directions.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\ClassicChess\\ChessHorseBlack.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\ClassicChess\\ChessHorseWhite.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoves =
        {
            new Position(1, 2),
            new Position(2, 1),
            new Position(-1, 2),
            new Position(-2, 1),
            new Position(1, -2),
            new Position(2, -1),
            new Position(-1, -2),
            new Position(-2, -1),
        };

        private readonly Position[] _avaibleAttacks =
        {
            new Position(1, 2),
            new Position(2, 1),
            new Position(-1, 2),
            new Position(-2, 1),
            new Position(1, -2),
            new Position(2, -1),
            new Position(-1, -2),
            new Position(-2, -1),
        };

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, bool> CanMove => (figure, moveToFigure) =>
            CanMoveSimple(figure, moveToFigure, _avaibleMoves);

        public Func<BaseFigure, BaseFigure, bool> CanAttack => (figure, attackFigure) =>
            CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}