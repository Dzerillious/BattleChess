using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Hobbit
{
    public class HobbitSoldier : SimpleFrontAttackFigure, IFigure
    {
        public string ShownName => "Soldier";
        public string UnitName => "HobbitSoldier";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 1;
        public string Description => "\nSteward of Gondor\n\nThe Stewards of Gondor were firstly the chief high councillors to the Kings of Gondor and then the rulers of Gondor, until the return of the rightful ruler King Aragorn II Elessar.\n" +
            "\nThe Great Spiders\n\nThe Great Spiders, also known as the Children of Ungoliant, were a race of oversized and sentient arachnids that lived in Middle-earth, particularly in dark and perilous places affected by the power of the Shadow.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Spider.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Beregond.png";
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

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanMove => (figure, moveToFigure, x) =>
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

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanAttack => (figure, attackFigure, x) =>
                 CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}