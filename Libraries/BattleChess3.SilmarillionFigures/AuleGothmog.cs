using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.SilmarillionFigures
{
    public class AuleGothmog : IFigureType
    {
        public string ShownName => "Aule/Gothmog";
        public string UnitName => "Silmarillion_AuleGothmog";
        public string GroupName => "Silmarillion";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;

        public string Description => "" +
            "\nAulë(Quenya; IPA: [ˈaʊle] - \"Invention\")\n\n" +
            "was an Ainur, one of the Aratar and a Valar, who was " +
            "responsible for fashioning and crafting the substances" +
            "of which Arda, the world, was composed.He was also called " +
            "Mahal (Khuzdul; IPA: \"Maker\"), Oli(Sindarin; IPA: \"Dream\")" +
            "or Návatar and delights in the nature of substances and " +
            "in works of skill, but not concerned with possession or mastery." +
            "Besides the shaping of Arda, Aulë's greatest works were the Two " +
            "Lamps of the Valar, the vessels of the Sun and Moon, and" +
            "the Dwarves, whom he created out of impatience for the Children " +
            "of Ilúvatar. He also created Angainor (the chain of Melkor)." +
            "\n\nGothmog (Sindarin IPA: [ˈɡoθmoɡ] - \"Strife and Hate\") \n\n" +
            "was the Lord of Balrogs during the First Age, and the greatest " +
            "Balrog ever to walk Middle-earth. As the High Captain of Angband, " +
            "his only equal in rank was Sauron. He fought many battles in the" +
            "name of his master Morgoth, and was personally responsible for" +
            "killing two of the High Kings of the Ñoldor. ";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}