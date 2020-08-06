using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Hobbit
{
    public class HobbitMinorWizzard : DirectionAttack, IFigure
    {
        public string ShownName => "Minor Wizzard";
        public string UnitName => "HobbitMinorWizzard";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 5;
        public string Description => "\nSaruman\n\nSaruman (Quenya; IPA: ['saruman] - \"Man Of Skill\"), also known as Saruman the White was an Istar (wizard), who lived in Middle-earth during the Third Age. Originally, he was the chief of the wizards and of the White Council that opposed Sauron. His extensive studies of dark magic, however, eventually led him to desire the One Ring for himself. Thinking he could ally himself with Sauron and then betray him, Saruman allied Isengard with Mordor in the War of the Ring, in which he was defeated.\n" +
            "\nRadagast\n\nRadagast (Adûnaic; IPA: ['radagast] - \"Tender Of Beasts\") the Brown, also called Aiwendil (Quenya; IPA: [ai'wendil] - \"Bird-Friend\") was one of the five Wizards, or Istari. He was a good friend of Gandalf the Grey, whom he aided occasionally. Radagast was mainly concerned with the well-being of the plant and animal worlds, and thus did not participate heavily in the War of the Ring.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Saruman.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Radagast.png";
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