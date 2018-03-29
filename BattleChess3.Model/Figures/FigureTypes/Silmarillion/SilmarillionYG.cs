using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Shared;
using BattleChess3.Shared.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes.Silmarillion
{
    public class SilmarillionYG : DirectionAttack, IFigure
    {
        public string ShownName => "Yavanna/Glaurung";
        public string UnitName => Resource.SilmarillionYG;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 3;
        public string Description => "\nYavanna\n\nYavanna (Quenya; IPA: [jaˈvanna] - \"Giver of Fruits\") was of the Ainur and Valar, and one of the Aratar who was responsible for the growth of all the fruits and growing things of Arda. She was also called Kementári (Quenya; IPA: \"Queen of the Earth\"), Ivon (Sindarin; IPA: \"Giver of Fruits\"). She resided in the Pastures of Yavanna, in the south of Valinor. She is the wife of Aulë, older sister of Vána,[2] and kin to Melian." +
            "\nGlaurung\n\nGlaurung was the first terrestrial, fire-breathing Dragon in Middle-earth. He is known as the Father of Dragons.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Glaurung.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Yavanna.png";
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