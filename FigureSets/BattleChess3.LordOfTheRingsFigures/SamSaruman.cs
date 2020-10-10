using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figure;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures
{
    public class SamSaruman : IFigureType
    {
        public static readonly SamSaruman Instance = new SamSaruman();
        public string ShownName => CurrentLocalization.Instance["SamSaruman_Name"];
        public string UnitName => $"{nameof(LordOfTheRingsFigureGroup)}.{nameof(SamSaruman)}";
        public string GroupName => nameof(LordOfTheRingsFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;
        public string Description => CurrentLocalization.Instance["SamSaruman_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/SamSaruman1.png", UriKind.Absolute)},
            {1, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/SamSaruman2.png", UriKind.Absolute)},
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