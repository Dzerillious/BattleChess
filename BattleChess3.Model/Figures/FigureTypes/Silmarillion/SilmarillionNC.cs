using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Model.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes.Silmarillion
{
    public class SilmarillionNC : DirectionAttack, IFigure
    {
        public string ShownName => "Mandos/Carcharoth";
        public string UnitName => "SilmarillionNC";
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 3;

        public string Description => "\nMandos\n\nMandos (Quenya; IPA: [ˈmandos] - \"Prison-Fortress\") is an Ainu, one of the Aratar and a Vala who is responsible for the judgement of the Spirits, or Fëa of all Elven dead. He also has responsibility for pronouncing the dooms and judgments of Eru Ilúvatar under Manwë. His real name is Námo (Quenya; IPA: \"Ordainer\" or \"Judge\") but was later known by the Elves as Mandos after his sacred halls Halls of Mandos, over which he presides and where ultimately the Elves go after they are slain.\n" +
            "\nCarcharoth\n\nCarcharoth, also known as the Red Maw, lived in the First Age of the Sun, and was the greatest werewolf who ever lived. He was of the line of Draugluin.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Carcharoth.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Namo.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoveDirections =
        {
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
        };

        private readonly Position[] _avaibleAttackDirections =
        {
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
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