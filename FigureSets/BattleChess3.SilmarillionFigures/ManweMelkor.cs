using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figure;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.SilmarillionFigures.Localization;

namespace BattleChess3.SilmarillionFigures
{
    public class ManweMelkor : IFigureType
    {
        public static readonly ManweMelkor Instance = new ManweMelkor();
        public string ShownName => CurrentLocalization.Instance["ManweMelkor_Name"];
        public string UnitName => $"{nameof(SilmarillionFigureGroup)}.{nameof(ManweMelkor)}";
        public string GroupName => nameof(SilmarillionFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 0;
        public string Description => CurrentLocalization.Instance["ManweMelkor_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/ManweMelkor1.png", UriKind.Absolute)},
            {1, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/ManweMelkor2.png", UriKind.Absolute)},
        };

        public void AttackAction(Position from, Position to, Tile[] board)
            => board[to].KillFigure(board);

        private readonly Position[][] _moveChain = 
        {
            new Position[] {(1, 1)},
            new Position[] {(1, 0)},
            new Position[] {(1, -1)},
            new Position[] {(0, 1)},
            new Position[] {(0, -1)},
            new Position[] {(-1, 1)},
            new Position[] {(-1, 0)},
            new Position[] {(-1, -1)},
        };
        public Position[][] GetMoveChains(Position position) => _moveChain;
        
        
        private readonly Position[][] _attackChain = 
        {
            new Position[] {(1, 1)},
            new Position[] {(1, 0)},
            new Position[] {(1, -1)},
            new Position[] {(0, 1)},
            new Position[] {(0, -1)},
            new Position[] {(-1, 1)},
            new Position[] {(-1, 0)},
            new Position[] {(-1, -1)},
        };
        public Position[][] GetAttackChains(Position position) => _attackChain;
    }
}