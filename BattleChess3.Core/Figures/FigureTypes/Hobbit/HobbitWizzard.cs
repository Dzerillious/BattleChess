using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Hobbit
{
    public class HobbitWizzard : DirectionAttack, IFigure
    {
        public string ShownName => "Wizzard";
        public string UnitName => "HobbitWizzard";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 5;
        public string Description => "\nGandalf\n\nGandalf (Norse; IPA: [gand:alf] - \"Elf of the Wand\" or \"Wand-elf\") the Grey, later known as Gandalf the White, and originally named Olórin (Quenya; IPA: [oˈloːrin] - \"Dreamer\" or \"Of Dreams\"), was an Istar (wizard), sent by the West in the Third Age to combat the threat of Sauron. He joined Thorin and his company to reclaim the Lonely Mountain from Smaug, convoked the Fellowship of the Ring to destroy the One Ring, and led the Free Peoples in the final campaign of the War of the Ring.\n"+
            "\nThe Witch-kig\n\nThe Witch-king of Angmar was the leader of the Nazgûl or Ringwraiths, and Sauron's second-in-command during the Second and Third Ages. Once a Númenórean king of men, he was corrupted by one of the nine Rings of Power that had been given to the lords of men, and became an undead wraith in the service of Sauron. After the first defeat of Sauron in the War of the Last Alliance, the Witch-king fled to Angmar, a kingdom he ruled for over thousands of years until he returned to Mordor to lead Sauron's armies in the War of the Ring. He stabbed Frodo Baggins on Weathertop during the first months of Frodo's venture out of the Shire to Rivendell.He was killed in the Battle of the Pelennor Fields by Meriadoc Brandybuck and Éowyn, niece of King Théoden, at the end of the War.  ";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\WitchKing.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Gandalf.png";
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

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanMove => (figure, moveToFigure, getFigureAtPosition) =>
                 CanMoveDirection(figure, moveToFigure, _avaibleMoveDirections, getFigureAtPosition);

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanAttack => (figure, attackFigure, getFigureAtPosition) =>
                 CanAttackDirection(figure, attackFigure, _avaibleAttackDirections, getFigureAtPosition);
    }
}