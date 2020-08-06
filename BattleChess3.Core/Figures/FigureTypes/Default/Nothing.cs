using System;

namespace BattleChess3.Core.Figures.FigureTypes.Default
{
    public class Nothing : IFigure
    {
        public static Nothing Instance { get; } = new Nothing();
        public string ShownName => "Empty tile";
        public string UnitName => "Nothing";
        public string GroupName => "Default";
        public FigureType UnitType => FigureType.Nothing;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 0;
        public int Defence => 1000;
        public bool MovingAttack => false;
        public string Description { get; } = "Empty tile, where you can go. It cannot be destroyed with almost any unit. It does not stop directional attack.";
        public int Cost => 0;
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}