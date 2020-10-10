using System;
using System.Collections.Generic;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Localization;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.DefaultFigures
{
    public class Empty : IFigureType
    {
        public static Empty Instance { get; } = new Empty();
        
        public static Figure Figure { get; }
            = new Figure(Instance)
            {
                Hp = 100,
                Owner = Player.Neutral
            };
        
        public string ShownName => CurrentLocalization.Instance["Empty_Name"];
        public string UnitName => $"{nameof(DefaultFigureGroup)}.{nameof(Empty)}";
        public string GroupName => nameof(DefaultFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Nothing;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 0;
        public double Defence => double.PositiveInfinity;
        public bool MovingAttack => false;
        public string Description { get; } = CurrentLocalization.Instance["Empty_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.DefaultFigures;component/Images/Empty0.png", UriKind.Absolute)},
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