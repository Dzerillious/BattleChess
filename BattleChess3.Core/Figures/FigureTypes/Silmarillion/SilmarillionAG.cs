using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Silmarillion
{
    public class SilmarillionAG : SimpleFrontAttackFigure, IFigure
    {
        public string ShownName => "Aule/Gothmog";
        public string UnitName => "SilmarillionAG";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
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

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Gothmog.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Aule.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoves =
        {
            new Position(1, 2),
            new Position(2, 1),
            new Position(-1, 2),
            new Position(-2, 1),
            new Position(1, -2),
            new Position(2, -1),
            new Position(-1, -2),
            new Position(-2, -1),
        };

        private readonly Position[] _avaibleAttacks =
        {
            new Position(1, 2),
            new Position(2, 1),
            new Position(-1, 2),
            new Position(-2, 1),
            new Position(1, -2),
            new Position(2, -1),
            new Position(-1, -2),
            new Position(-2, -1),
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