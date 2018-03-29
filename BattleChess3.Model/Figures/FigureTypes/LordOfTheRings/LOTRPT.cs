using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Shared;
using BattleChess3.Shared.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes.LordOfTheRings
{
    public class LOTRPT : DirectionAttack, IFigure
    {
        public string ShownName => "Peregrin/Troll";
        public string UnitName => Resource.LOTRPT;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 3;
        public string Description => "\nPerregrin Took\n\nPeregrin Took, more commonly known as Pippin, was a Hobbit of the Shire, and one of Frodo Baggins's youngest, but closest friends. He was a member of the Fellowship of the Ring.\n" +
            "\nTrolls\n\nTrolls were a very large and monstrous (ranging from between 10-18 feet tall), and for the most part unintelligent (references are made about more cunning trolls), humanoid race inhabiting Middle-earth.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\LordOfTheRings\\Troll.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\LordOfTheRings\\Peregrin.png";
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