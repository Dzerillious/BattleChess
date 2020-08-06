using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Hobbit
{
    public class HobbitHelper : DirectionAttack, IFigure
    {
        public string ShownName => "Helper";
        public string UnitName => "HobbitHelper";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 3;
        public string Description => "\nOri\n\nOri was a member of Thorin's Company of Dwarves. He, alongside his brothers Dori and Nori, are remote kinsman of Thorin.\n" +
            "\nFelgrom\n\nFelgrom was the character created from LOTR: Two Towers which blows up the sewer grate to achieve entrance into Helms Deep. Warner Bros. elaborated upon the character, giving him a name and he is playable as a Tactician in their game: Guardians of Middle-earth. He is a suicide bomber, with several Orcish explosives strapped to his back. He is non-canonical as he doesn't appear in the books.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Felgrom.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Ori.png";
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

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanMove => (figure, moveToFigure, getFigureAtPosition) =>
                 CanMoveDirection(figure, moveToFigure, _avaibleMoveDirections, getFigureAtPosition);

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanAttack => (figure, attackFigure, getFigureAtPosition) =>
                 CanAttackDirection(figure, attackFigure, _avaibleAttackDirections, getFigureAtPosition);
    }
}