using System;

namespace BattleChess3.Core.Figures.FigureTypes.Default
{
    public class Ninja : IFigure
    {
        public string ShownName => "Ninja";
        public string UnitName => "Ninja";
        public string GroupName => "Default";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Foot;
        public FigureType AntiBonus => FigureType.Mount;
        public int Attack => 50;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 1;
        public string Description => "Ninja is secret warrior and with his diagonal moves can /nhe easily surprise enemy. He is one of cheap figures so he is best in front line.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}