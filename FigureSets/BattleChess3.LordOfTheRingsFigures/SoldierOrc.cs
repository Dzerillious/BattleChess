using System;
using System.Collections.Generic;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures
{
    public class SoldierOrc : IFigureType
    {
        public static readonly SoldierOrc Instance = new SoldierOrc();
        public string ShownName => CurrentLocalization.Instance["SoldierOrc_Name"];
        public string UnitName => $"{nameof(LordOfTheRingsFigureGroup)}.{nameof(SoldierOrc)}";
        public string GroupName => nameof(LordOfTheRingsFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 1;
        public string Description => CurrentLocalization.Instance["SoldierOrc_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {1, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/SoldierOrc1.png", UriKind.Absolute)},
            {2, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/SoldierOrc2.png", UriKind.Absolute)},
        };

        public void AttackAction(Position from, Position to, Tile[] board)
            => board[to].KillFigure(board);

        private readonly Position[][] _firstMoveChain = 
        {
            new Position[] {(1, 0), (2, 0)},
        };
        private readonly Position[][] _moveChain = 
        {
            new Position[] {(1, 0)},
        };
        public Position[][] MoveChain(Position position) 
            => position.X == 1 ? _firstMoveChain : _moveChain;


        private readonly Position[][] _attackChain = 
        {
            new Position[] {(1, 1)},
            new Position[] {(1, -1)},
        };
        public Position[][] AttackChain(Position position) => _attackChain;
    }
}