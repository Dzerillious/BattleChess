using System;

namespace BattleChess3.Core.Figures.FigureTypes.LordOfTheRings
{
    public class LOTRGW : IFigure
    {
        public string ShownName => "Gandalf/Witch king";
        public string UnitName => "LOTRGW";
        public string GroupName => "LOTR";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 9;

        public string Description => "\nGandalf\n\nGandalf (Norse; IPA: [gand:alf] - \"Elf of the Wand\" or \"Wand-elf\") the Grey, later known as Gandalf the White, and originally named Olórin (Quenya; IPA: [oˈloːrin] - \"Dreamer\" or \"Of Dreams\"), was an Istar (wizard), sent by the West in the Third Age to combat the threat of Sauron. He joined Thorin and his company to reclaim the Lonely Mountain from Smaug, convoked the Fellowship of the Ring to destroy the One Ring, and led the Free Peoples in the final campaign of the War of the Ring.\n" +
            "\nWitch-king\n\nThe Witch-king of Angmar was the leader of the Nazgûl or Ringwraiths, and Sauron's second-in-command during the Second and Third Ages. Once a Númenórean king of men, he was corrupted by one of the nine Rings of Power that had been given to the lords of men, and became an undead wraith in the service of Sauron. After the first defeat of Sauron in the War of the Last Alliance, the Witch-king fled to Angmar, a kingdom he ruled for over thousands of years until he returned to Mordor to lead Sauron's armies in the War of the Ring. He stabbed Frodo Baggins on Weathertop during the first months of Frodo's venture out of the Shire to Rivendell.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}