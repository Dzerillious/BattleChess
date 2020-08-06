using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Default
{
    public class Ninja : SimpleFrontAttackFigure, IFigure
    {
        public string ShownName => "Ninja";
        public string UnitName => "Ninja";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Foot;
        public FigureType AntiBonus => FigureType.Mount;
        public int Attack => 50;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 1;
        public string Description => "Ninja is secret warrior and with his diagonal moves can /nhe easily surprise enemy. He is one of cheap figures so he is best in front line.";

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

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanMove => (figure, moveToFigure, x) =>
                 CanMoveSimple(figure, moveToFigure, _avaibleMoves);

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanAttack => (figure, attackFigure, x) =>
                 CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}