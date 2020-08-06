using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Hobbit
{
    public class HobbitLeader : SimpleAttackFigure, IFigure
    {
        public string ShownName => "Leader";
        public string UnitName => "HobbitLeader";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 0;
        public string Description => "\nGaladriel\n\nGaladriel was the co-ruler and Lady of Lothlórien alongside her husband, Lord Celeborn - however, neither of them took royal titles, as they only saw themselves as the Guardians of The Golden Wood. She was the only daughter and youngest child of Finarfin, prince of the Ñoldor and of Eärwen, whose cousin was Lúthien.Her elder brothers were Finrod Felagund, Orodreth, Angrod, and Aegnor. Galadriel was a niece of Fëanor, one of the most important elves of the First Age. She was one of the greatest of the Eldar in Middle-earth, and surpassed nearly all others in beauty, knowledge, and power. She was also the bearer of Nenya, one of the three Elven rings of power. Tolkien thought of her, along with Gil-galad the Elven-king, as one of the mightiest and fairest of all the Elves left in Middle-earth.\n" +
            "\nSauron\n\nSauron (or Þauron (Thauron); Quenya; IPA: [ˈsaʊron] or Vanyarin; IPA: [ˈθaʊron] - \"The Abhorred\"), the eponymous Lord of the Rings, was a fallen Maia, the creator of the One Ring, and the most trusted lieutenant of his master Melkor (Morgoth, the first Dark Lord). After Melkor's defeat in the First Age, Sauron became the second Dark Lord and strove to conquer Arda by creating the Rings of Power. In the Second Age, he was defeated in the War of the Last Alliance by the last line of defense: Elves and Men under kings Gil-galad and Elendil. ";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Sauron.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Galadriel.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoves =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
        };

        private readonly Position[] _avaibleAttacks =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
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