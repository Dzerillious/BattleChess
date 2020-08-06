using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Silmarillion
{
    public class SilmarillionNB : DirectionAttack, IFigure
    {
        public string ShownName => "Nienna/Balrog";
        public string UnitName => "SilmarillionNB";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 5;

        public string Description => "\nNienna\n\nNienna (Quenya; IPA [niˈenna] or [niˈjenna] - \"Weeping\" or \"She Who Weeps\") was an Ainu, one of the Aratar and a Vala who was responsible for the mercy and grief spread across Arda. She was the sister of Mandos and Irmo and had no spouse. Her part in the Music of the Ainur was one of deep sadness, from which grief entered the world at its beginning. She had dominion over the Halls of Nienna, which were on the western edge of Valinor, looking over the sea.\n" +
            "\nBalrog\n\nBalrogs, also known as the Valaraukar, were Maiar that were seduced and corrupted by Melkor into his service. Originally, Balrogs were Maiar that were later persuaded by Melkor before the Awakening of the Elves. Their first dwellings had been Utumno, but after their master's defeat during the War for Sake of the Elves, the Balrogs and other creatures in Melkor's service escaped and went to Angband.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Balrog.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Nienna.png";
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