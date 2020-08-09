using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.LordOfTheRings
{
    public class GimliNazgul : IFigureType
    {
        public string ShownName => "Gimli/Nazgul";
        public string UnitName => "LOTR_GimliNazgul";
        public string GroupName => "LOTR";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 5;

        public string Description => "\nGimli\n\nGimli, son of Glóin, was a well-respected dwarf warrior in Middle-earth during the Great Years. He was a member of the Fellowship of the Ring, and was the only one of the dwarves to readily fight alongside elves in the war against Sauron at the end of the Third Age. After the defeat of Sauron, he was given lordship of the Glittering Caves at Helm's Deep.\n" +
            "\nNazgûl\n\nThe Nazgûl (also known as Ringwraiths, The Nine, The Fallen Kings, Black Riders, Nunbolg, or Ulairi in Quenya) were the dreaded ring-servants of the Dark Lord Sauron in Middle-earth throughout the Second and Third ages, and in the later years of the Third Age, they dwelt in Minas Morgul and Dol Guldur.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}