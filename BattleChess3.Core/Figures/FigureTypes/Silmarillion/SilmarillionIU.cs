using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Silmarillion
{
    public class SilmarillionIU : SimpleAttackFigure, IFigure
    {
        public string ShownName => "Irmo/Ungoliant";
        public string UnitName => "SilmarillionIU";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 3;

        public string Description => "\nIrmo\n\nIrmo (Quenya; IPA: [ˈirmo] - \"Desirer\" or \"Master of Desires\") is an Ainu, and a Vala who was responsible for the creation of dreams and desires as well as visions too. He was more commonly known as Lórien, after the name of his dwelling place. Irmo-Lórien was the younger brother of Námo who also like his brother was commonly known as Mandos the name of his dwelling place, and also the brother of Nienna (Lady of Pity and Mourning).\n" +
            "\nUngoliant\n\nUngoliant (Sindarin IPA: [uŋˈɡoljant] - \"Dark Spider\") was a primordial taking the shape of a gigantic spider. She was initially an ally of Melkor in Aman, and for a short time in Middle-earth as well. She is the mother of Shelob, and therefore the oldest, and first spider of the south, possibly even the first spider. ";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Ungoliant.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Irmo.png";
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

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanMove => (figure, moveToFigure, x) =>
                 CanMoveSimple(figure, moveToFigure, _avaibleMoves);

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanAttack => (figure, attackFigure, x) =>
                 CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}