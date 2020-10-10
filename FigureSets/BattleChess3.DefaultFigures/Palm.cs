using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.DefaultFigures
{
    public class Palm : IFigureType
    {
        public static readonly Palm Instance = new Palm();
        public string ShownName => CurrentLocalization.Instance["Palm_Name"];
        public string Description => CurrentLocalization.Instance["Palm_Description"];
        public string UnitName { get; } = $"{nameof(DefaultFigureGroup)}.{nameof(Palm)}";
        public FigureTypes UnitTypes { get; } = FigureTypes.Object;
        public FigureTypes Bonus { get; } = FigureTypes.Nothing;
        public FigureTypes AntiBonus { get; } = FigureTypes.Nothing;
        public double Attack { get; } = 0;
        public double Defence { get; } = -50;
        public bool MovingAttack { get; } = false;

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {-1, new Uri("pack://application:,,,/BattleChess3.DefaultFigures;component/Images/Palm0.png", UriKind.Absolute)},
        };

        public int Cost => 0;

        public void AttackAction(Tile from, Tile to, Tile[] board)
        {
        }

        public void MoveAction(Tile from, Tile to, Tile[] board)
        {
        }

        private readonly Position[][] _moveChain = { };
        public Position[][] GetMoveChains(Position position) => _moveChain;
        
        
        private readonly Position[][] _attackChain = { };
        public Position[][] GetAttackChains(Position position) => _attackChain;
    }
}