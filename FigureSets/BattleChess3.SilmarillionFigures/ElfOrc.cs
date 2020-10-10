using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figure;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.SilmarillionFigures.Localization;

namespace BattleChess3.SilmarillionFigures
{
    public class ElfOrc : IFigureType
    {
        public static readonly ElfOrc Instance = new ElfOrc();
        public string ShownName => CurrentLocalization.Instance["ElfOrc_Name"];
        public string UnitName => $"{nameof(SilmarillionFigureGroup)}.{nameof(ElfOrc)}";
        public string GroupName => nameof(SilmarillionFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 1;
        public string Description => CurrentLocalization.Instance["ElfOrc_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/ElfOrc1.png", UriKind.Absolute)},
            {1, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/ElfOrc2.png", UriKind.Absolute)},
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
        public Position[][] GetMoveChains(Position position) 
            => position.Y == 1 ? _firstMoveChain : _moveChain;


        private readonly Position[][] _attackChain = 
        {
            new Position[] {(1, 1)},
            new Position[] {(1, -1)},
        };
        public Position[][] GetAttackChains(Position position) => _attackChain;
    }
}