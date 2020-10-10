using System;
using System.Collections.Generic;
using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figure;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.ChessFigures
{
    public class Knight : IFigureType
    {
        public static readonly Knight Instance = new Knight();
        public string ShownName => CurrentLocalization.Instance["Knight_Name"];
        public string UnitName => $"{nameof(ChessFigureGroup)}.{nameof(Knight)}";
        public string GroupName => nameof(ChessFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Mount;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;
        public string Description => CurrentLocalization.Instance["Knight_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Knight1.png", UriKind.Absolute)},
            {1, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Knight2.png", UriKind.Absolute)},
        };

        public void AttackAction(Position from, Position to, Tile[] board)
            => board[to].KillFigure(board);

        private readonly Position[][] _moveChain = 
        {
            new Position[] {(-2, 1)},
            new Position[] {(-2, -1)},
            new Position[] {(2, 1)},
            new Position[] {(2, -1)},
            new Position[] {(-1, -2)},
            new Position[] {(1, -2)},
            new Position[] {(-1, 2)},
            new Position[] {(1, 2)},
        };
        public Position[][] GetMoveChains(Position position) => _moveChain;
        
        
        private readonly Position[][] _attackChain = 
        {
            new Position[] {(-2, 1)},
            new Position[] {(-2, -1)},
            new Position[] {(2, 1)},
            new Position[] {(2, -1)},
            new Position[] {(-1, -2)},
            new Position[] {(1, -2)},
            new Position[] {(-1, 2)},
            new Position[] {(1, 2)},
        };
        public Position[][] GetAttackChains(Position position) => _attackChain;
    }
}