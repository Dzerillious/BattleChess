using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.HobbitFigures
{
    public class Leader : IFigureType
    {
        public static readonly Leader Instance = new Leader();
        public string ShownName => "Leader";
        public string UnitName => "Hobbit_Leader";
        public string GroupName => "Hobbit";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 0;
        public string Description => "\nGaladriel\n\nGaladriel was the co-ruler and Lady of Lothlórien alongside her husband, Lord Celeborn - however, neither of them took royal titles, as they only saw themselves as the Guardians of The Golden Wood. She was the only daughter and youngest child of Finarfin, prince of the Ñoldor and of Eärwen, whose cousin was Lúthien.Her elder brothers were Finrod Felagund, Orodreth, Angrod, and Aegnor. Galadriel was a niece of Fëanor, one of the most important elves of the First Age. She was one of the greatest of the Eldar in Middle-earth, and surpassed nearly all others in beauty, knowledge, and power. She was also the bearer of Nenya, one of the three Elven rings of power. Tolkien thought of her, along with Gil-galad the Elven-king, as one of the mightiest and fairest of all the Elves left in Middle-earth.\n" +
            "\nSauron\n\nSauron (or Þauron (Thauron); Quenya; IPA: [ˈsaʊron] or Vanyarin; IPA: [ˈθaʊron] - \"The Abhorred\"), the eponymous Lord of the Rings, was a fallen Maia, the creator of the One Ring, and the most trusted lieutenant of his master Melkor (Morgoth, the first Dark Lord). After Melkor's defeat in the First Age, Sauron became the second Dark Lord and strove to conquer Arda by creating the Rings of Power. In the Second Age, he was defeated in the War of the Last Alliance by the last line of defense: Elves and Men under kings Gil-galad and Elendil. ";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}