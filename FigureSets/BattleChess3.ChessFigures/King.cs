using System;
using System.Collections.Generic;
using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figure;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.ChessFigures
{
    public class King : IFigureType
    {
        public static readonly King Instance = new King();
        public string ShownName => CurrentLocalization.Instance["King_Name"];
        public string UnitName => $"{nameof(ChessFigureGroup)}.{nameof(King)}";
        public string GroupName => nameof(ChessFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Special;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 0;
        public string Description => CurrentLocalization.Instance["King_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/King1.png", UriKind.Absolute)},
            {1, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/King2.png", UriKind.Absolute)},
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