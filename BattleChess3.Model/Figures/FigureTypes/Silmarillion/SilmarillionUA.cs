using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Shared;
using BattleChess3.Shared.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes.Silmarillion
{
    public class SilmarillionUA : DirectionAttack, IFigure
    {
        public string ShownName => "Ulmo/Ancalagon";
        public string UnitName => Resource.SilmarillionUA;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 9;
        public string Description => "\nUlmo\n\nUlmo (Quenya; IPA: [ˈulmo] - \"Pourer\" or \"Rainer\") - also known as Ulubôz or Ullubôz - was an Ainu, one of the Aratar, and the Vala responsible for the control over the oceans of Arda. A lover of water, Ulmo was one of the Arda's chief architects and was always in a close friendship with Manwë. He always distrusted Melkor, and the Dark Lord feared the Sea almost as much as he feared Varda because the sea cannot be tamed. Ulmo had no dwelling in Valinor or any permanent dwelling on land, as he preferred the deeps of the seas and the rivers. His palace, on the bottom of Vaiya, was called Ulmonan.\n" +
            "\nAncalagon\n\nAncalagon, also known as Ancalagon the Black, was the greatest of all winged dragons. He was bred by Morgoth during the First Age, and was the largest dragon to have ever existed in Middle-earth. ";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Ancalagon.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Ulmo.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoveDirections =
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

        private readonly Position[] _avaibleAttackDirections =
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

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanMove => (figure, moveToFigure, getFigureAtPosition) =>
                CanMoveDirection(figure, moveToFigure, _avaibleMoveDirections, getFigureAtPosition);

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanAttack => (figure, attackFigure, getFigureAtPosition) =>
                CanAttackDirection(figure, attackFigure, _avaibleAttackDirections, getFigureAtPosition);
    }
}