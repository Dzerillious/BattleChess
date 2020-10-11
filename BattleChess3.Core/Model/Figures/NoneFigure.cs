using System;
using System.Collections.Generic;

namespace BattleChess3.Core.Model.Figures
{
    public class NoneFigure : IFigureType
    {
        public static IFigureType Instance { get; } = new NoneFigure();
        
        public string ShownName { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public string UnitName { get; } = string.Empty;
        public FigureTypes UnitTypes { get; } = FigureTypes.Nothing;
        public FigureTypes Bonus { get; } = FigureTypes.Nothing;
        public FigureTypes AntiBonus { get; } = FigureTypes.Nothing;
        public double FullHp { get; } = 0;
        public double Attack { get; } = 0;
        public double Defence { get; } = 0;
        public bool MovingAttack { get; } = false;
        public int Cost { get; } = 0;
        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>();

        public void AttackAction(ITile from, ITile to, ITile[] board)
        {
        }

        public void MoveAction(ITile from, ITile to, ITile[] board)
        {
        }

        public Position[][] GetMoveChains(Position from) => Array.Empty<Position[]>();

        public Position[][] GetAttackChains(Position from) => Array.Empty<Position[]>();
    }
}