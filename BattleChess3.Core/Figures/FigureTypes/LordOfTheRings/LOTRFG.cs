using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.LordOfTheRings
{
    public class LOTRFG : SimpleAttackFigure, IFigure
    {
        public string ShownName => "Frodo/Gollum";
        public string UnitName => "LOTRFG";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 3;

        public string Description => "\nFrodo\n\nFrodo Baggins, son of Drogo Baggins, was a Hobbit of the Shire during the Third Age. He was, and still is, Tolkien's most renowned character for his leading role in the Quest of the Ring, in which he bore the One Ring to Mount Doom, where it was destroyed. He was a Ring-bearer, best friend to his gardener, Samwise Gamgee, and one of the three Hobbits who sailed from Middle-earth to the Uttermost West at the end of the Third Age.\n" +
            "\nGollum\n\nGollum, originally known as Sméagol (or Trahald), was at first a Stoor, one of the three early Hobbit-types. The name Gollum was derived from the sound of his disgusting gurgling, choking cough. His birth can be estimated to have happened in the year TA 2430. His death date is given as March 25, 3019. His life was extended far beyond its natural limits by the effects of possessing the One Ring. At the time of his death, Sméagol was about 589 years old, a remarkable age for a creature that was once a Hobbit, but he had been deformed and twisted in both body and mind by the corruption of the Ring. His chief desire was to possess the Ring that had enslaved him, and he pursued it for many years after Bilbo Baggins found it while walking in the Misty Mountains in the book The Hobbit. In the movies, he was a deuteragonist-turned-secondary antagonist.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\LordOfTheRings\\Gollum.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\LordOfTheRings\\Frodo.png";
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

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanMove => (figure, moveToFigure, x) =>
                 CanMoveSimple(figure, moveToFigure, _avaibleMoves);

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanAttack => (figure, attackFigure, x) =>
                 CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}