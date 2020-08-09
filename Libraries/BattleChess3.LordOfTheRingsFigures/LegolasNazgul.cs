using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.LordOfTheRings
{
    public class LegolasNazgul : IFigureType
    {
        public string ShownName => "Legolas/Nazgul";
        public string UnitName => "LOTR_LegolasNazgul";
        public string GroupName => "LOTR";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 5;

        public string Description => "\nLegolas\n\nLegolas was a Sindarin elf who was part of the Fellowship of the Ring in the Third Age. As he was the son of the Elvenking Thranduil of Mirkwood, Legolas was Prince of the Woodland Realm (Mirkwood), a messenger, and a master bowman. With his keen eyesight, sensitive hearing, and excellent bowmanship, Legolas was a valuable resource to the other members of the Fellowship. He was well-known for becoming friends with the dwarf Gimli, despite their long-held differences. It is not known whether Legolas was Thranduil's only son, or whether he was his heir. His age is unknown as well.\n" +
            "\nNazgûl\n\nThe Nazgûl (also known as Ringwraiths, The Nine, The Fallen Kings, Black Riders, Nunbolg, or Ulairi in Quenya) were the dreaded ring-servants of the Dark Lord Sauron in Middle-earth throughout the Second and Third ages, and in the later years of the Third Age, they dwelt in Minas Morgul and Dol Guldur.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}