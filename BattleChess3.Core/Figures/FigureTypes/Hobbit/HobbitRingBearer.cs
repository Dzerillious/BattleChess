using System;

namespace BattleChess3.Core.Figures.FigureTypes.Hobbit
{
    public class HobbitRingBearer : IFigure
    {
        public string ShownName => "Ring bearer";
        public string UnitName => "HobbitRingBearer";
        public string GroupName => "Hobbit";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 9;
        public string Description => "\nFrodo Baggins\n\nFrodo Baggins, son of Drogo Baggins, was a Hobbit of the Shire during the Third Age. He was, and still is, Tolkien's most renowned character for his leading role in the Quest of the Ring, in which he bore the One Ring to Mount Doom, where it was destroyed. He was a Ring-bearer, best friend to his gardener, Samwise Gamgee, and one of the three Hobbits who sailed from Middle-earth to the Uttermost West at the end of the Third Age.\n" +
            "\nGollum\n\n Gollum, originally known as Sméagol (or Trahald), was at first a Stoor, one of the three early Hobbit-types. The name Gollum was derived from the sound of his disgusting gurgling, choking cough. His birth can be estimated to have happened in the year TA 2430. His death date is given as March 25, 3019. His life was extended far beyond its natural limits by the effects of possessing the One Ring. At the time of his death, Sméagol was about 589 years old, a remarkable age for a creature that was once a Hobbit, but he had been deformed and twisted in both body and mind by the corruption of the Ring. His chief desire was to possess the Ring that had enslaved him, and he pursued it for many years after Bilbo Baggins found it while walking in the Misty Mountains in the book The Hobbit. In the movies, he was a deuteragonist-turned-secondary antagonist.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}