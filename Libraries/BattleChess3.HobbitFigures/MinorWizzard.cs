using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.HobbitFigures
{
    public class MinorWizzard : IFigureType
    {
        public static readonly MinorWizzard Instance = new MinorWizzard();
        public string ShownName => "Minor Wizzard";
        public string UnitName => "Hobbit_MinorWizzard";
        public string GroupName => "Hobbit";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 5;
        public string Description => "\nSaruman\n\nSaruman (Quenya; IPA: ['saruman] - \"Man Of Skill\"), also known as Saruman the White was an Istar (wizard), who lived in Middle-earth during the Third Age. Originally, he was the chief of the wizards and of the White Council that opposed Sauron. His extensive studies of dark magic, however, eventually led him to desire the One Ring for himself. Thinking he could ally himself with Sauron and then betray him, Saruman allied Isengard with Mordor in the War of the Ring, in which he was defeated.\n" +
            "\nRadagast\n\nRadagast (Adûnaic; IPA: ['radagast] - \"Tender Of Beasts\") the Brown, also called Aiwendil (Quenya; IPA: [ai'wendil] - \"Bird-Friend\") was one of the five Wizards, or Istari. He was a good friend of Gandalf the Grey, whom he aided occasionally. Radagast was mainly concerned with the well-being of the plant and animal worlds, and thus did not participate heavily in the War of the Ring.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}