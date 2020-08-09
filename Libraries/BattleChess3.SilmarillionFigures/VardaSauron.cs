using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.SilmarillionFigures
{
    public class VardaSauron : IFigureType
    {
        public static readonly VardaSauron Instance = new VardaSauron();
        public string ShownName => "Varda/Sauron";
        public string UnitName => "Silmarillion_VardaSauron";
        public string GroupName => "Silmarillion";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 5;

        public string Description => "\nVarda\n\nVarda (Quenya; IPA: [ˈvarda] - \"Sublime\" or \"Lofty\") is an Ainu, and one of the Aratar and a Vala who was responsible for the outlining of the stars in the heavens above Arda. She was also known as Elbereth (Sindarin; IPA: \"Queen of the Stars\") or Gilthoniel, and was the spouse of Manwë, with whom she lives in Ilmarin on the summit of Taniquetil in Aman.\n" +
            "\nSauron\n\nSauron (or Þauron (Thauron); Quenya; IPA: [ˈsaʊron] or Vanyarin; IPA: [ˈθaʊron] - \"The Abhorred\"), the eponymous Lord of the Rings, was a fallen Maia, the creator of the One Ring, and the most trusted lieutenant of his master Melkor (Morgoth, the first Dark Lord). After Melkor's defeat in the First Age, Sauron became the second Dark Lord and strove to conquer Arda by creating the Rings of Power. In the Second Age, he was defeated in the War of the Last Alliance by the last line of defense: Elves and Men under kings Gil-galad and Elendil. ";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}