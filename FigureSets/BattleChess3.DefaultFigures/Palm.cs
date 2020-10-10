using System;
using System.Collections.Generic;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.DefaultFigures
{
    public class Palm : IFigureType
    {
        public static readonly Palm Instance = new Palm();
        public string ShownName => CurrentLocalization.Instance["Palm_Name"];
        public string UnitName => $"{nameof(DefaultFigureGroup)}.{nameof(Palm)}";
        public string GroupName => nameof(DefaultFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Object;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 0;
        public double Defence => -50;
        public bool MovingAttack => false;
        public string Description => CurrentLocalization.Instance["Palm_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.DefaultFigures;component/Images/Palm0.png", UriKind.Absolute)},
        };

        public int Cost => 0;

        public void AttackAction(Position from, Position to, Tile[] board)
        {
        }

        private readonly Position[][] _moveChain = { };
        public Position[][] MoveChain(Position position) => _moveChain;
        
        
        private readonly Position[][] _attackChain = { };
        public Position[][] AttackChain(Position position) => _attackChain;
    }
}