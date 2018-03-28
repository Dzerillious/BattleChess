using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes
{
    public class Ninja : SimpleFrontAttackFigure, IFigure
    {
        public string UnitName => Resource.Ninja;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Foot;
        public string AntiBonus => Resource.Mount;
        public int Attack => 50;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 1;
        public string Description => "Ninja is secret warrior and with his diagonal moves can he easily surprise enemy. He is one of cheap figures so he is best in front line.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\NinjaBlack.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\NinjaWhite.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoves =
        {
            new Position(1, 1),
            new Position(-1, 1),
            new Position(-1, -1),
            new Position(1, -1)
        };

        private readonly Position[] _avaibleAttacks =
        {
            new Position(0, 1),
            new Position(-1, 0),
            new Position(0, -1),
            new Position(1, 0)
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