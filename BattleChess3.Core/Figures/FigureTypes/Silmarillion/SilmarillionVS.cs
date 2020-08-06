using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Silmarillion
{
    public class SilmarillionVS : DirectionAttack, IFigure
    {
        public string ShownName => "Varda/Sauron";
        public string UnitName => "SilmarillionVS";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 5;

        public string Description => "\nVarda\n\nVarda (Quenya; IPA: [ˈvarda] - \"Sublime\" or \"Lofty\") is an Ainu, and one of the Aratar and a Vala who was responsible for the outlining of the stars in the heavens above Arda. She was also known as Elbereth (Sindarin; IPA: \"Queen of the Stars\") or Gilthoniel, and was the spouse of Manwë, with whom she lives in Ilmarin on the summit of Taniquetil in Aman.\n" +
            "\nSauron\n\nSauron (or Þauron (Thauron); Quenya; IPA: [ˈsaʊron] or Vanyarin; IPA: [ˈθaʊron] - \"The Abhorred\"), the eponymous Lord of the Rings, was a fallen Maia, the creator of the One Ring, and the most trusted lieutenant of his master Melkor (Morgoth, the first Dark Lord). After Melkor's defeat in the First Age, Sauron became the second Dark Lord and strove to conquer Arda by creating the Rings of Power. In the Second Age, he was defeated in the War of the Last Alliance by the last line of defense: Elves and Men under kings Gil-galad and Elendil. ";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Sauron.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Varda.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoveDirections =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
        };

        private readonly Position[] _avaibleAttackDirections =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
        };

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanMove => (figure, moveToFigure, getFigureAtPosition) =>
                 CanMoveDirection(figure, moveToFigure, _avaibleMoveDirections, getFigureAtPosition);

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanAttack => (figure, attackFigure, getFigureAtPosition) =>
                 CanAttackDirection(figure, attackFigure, _avaibleAttackDirections, getFigureAtPosition);
    }
}