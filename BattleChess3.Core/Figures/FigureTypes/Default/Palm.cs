using System;

namespace BattleChess3.Core.Figures.FigureTypes.Default
{
    public class Palm : IFigure
    {
        public string ShownName => "Palm";
        public string UnitName => "Palm";
        public string GroupName => "Default";
        public FigureType UnitType => FigureType.Object;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 0;
        public int Defence => -50;
        public bool MovingAttack => false;
        public string Description => "Palm tile, which you can easily destroy. It cannot move and belongs to no one";
        public int Cost => 0;
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}