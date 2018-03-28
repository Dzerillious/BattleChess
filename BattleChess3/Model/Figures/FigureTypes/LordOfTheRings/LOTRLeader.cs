using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes.LordOfTheRings
{
    public class LOTRLeader : SimpleAttackFigure, IFigure
    {
        public string UnitName => "LOTRLeader";
        public string UnitType => Resource.Mount;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 3;

        public string Description =>
            "Chess horse is quite movable unit which can easily suprise enemy, because his attacks are definet by many points, not directions.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\LOTR\\Sauron.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\LOTR\\Galadriel.png";
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