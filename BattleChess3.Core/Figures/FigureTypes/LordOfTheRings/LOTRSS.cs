using System;

namespace BattleChess3.Core.Figures.FigureTypes.LordOfTheRings
{
    public class LOTRSS : IFigure
    {
        public string ShownName => "Sam/Saruman";
        public string UnitName => "LOTRSS";
        public string GroupName => "LOTR";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;

        public string Description => "\nSamwise Gamgee\n\nSamwise Gamgee, also known as Sam, was a Hobbit of the Shire. He was Frodo Baggins' gardener and best friend. Sam proved himself to be Frodo's closest and most dependable companion, the most loyal of the Fellowship of the Ring, and also played a necessary role in protecting Frodo and destroying the One Ring.\n" +
            "\nSaruman\n\nSaruman (Quenya; IPA: ['saruman] - \"Man Of Skill\"), also known as Saruman the White was an Istar (wizard), who lived in Middle-earth during the Third Age. Originally, he was the chief of the wizards and of the White Council that opposed Sauron. His extensive studies of dark magic, however, eventually led him to desire the One Ring for himself. Thinking he could ally himself with Sauron and then betray him, Saruman allied Isengard with Mordor in the War of the Ring, in which he was defeated. He studied deeply the arts of Sauron, the better to oppose him, but he soon became enamored of Sauron's devices, especially the One Ring. He betrayed his mission and sought the power of the Ring for himself. He initially advocated an alliance with Sauron, but he soon betrayed Sauron as well, as his ultimate goal was to supplant Sauron and rule Middle-earth. But his plans came to nought, and his power was broken in the Battle of the Hornburg and the Battle of Isengard. ";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}