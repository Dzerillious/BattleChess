using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.LordOfTheRings
{
    public class LOTRLN : DirectionAttack, IFigure
    {
        public string ShownName => "Legolas/Nazgul";
        public string UnitName => "LOTRLN";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 5;

        public string Description => "\nLegolas\n\nLegolas was a Sindarin elf who was part of the Fellowship of the Ring in the Third Age. As he was the son of the Elvenking Thranduil of Mirkwood, Legolas was Prince of the Woodland Realm (Mirkwood), a messenger, and a master bowman. With his keen eyesight, sensitive hearing, and excellent bowmanship, Legolas was a valuable resource to the other members of the Fellowship. He was well-known for becoming friends with the dwarf Gimli, despite their long-held differences. It is not known whether Legolas was Thranduil's only son, or whether he was his heir. His age is unknown as well.\n" +
            "\nNazgûl\n\nThe Nazgûl (also known as Ringwraiths, The Nine, The Fallen Kings, Black Riders, Nunbolg, or Ulairi in Quenya) were the dreaded ring-servants of the Dark Lord Sauron in Middle-earth throughout the Second and Third ages, and in the later years of the Third Age, they dwelt in Minas Morgul and Dol Guldur.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\LordOfTheRings\\Nazgul.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\LordOfTheRings\\Legolas.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoveDirections =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
        };

        private readonly Position[] _avaibleAttackDirections =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
        };

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanMove => (figure, moveToFigure, getFigureAtPosition) =>
                 CanMoveDirection(figure, moveToFigure, _avaibleMoveDirections, getFigureAtPosition);

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanAttack => (figure, attackFigure, getFigureAtPosition) =>
                 CanAttackDirection(figure, attackFigure, _avaibleAttackDirections, getFigureAtPosition);
    }
}