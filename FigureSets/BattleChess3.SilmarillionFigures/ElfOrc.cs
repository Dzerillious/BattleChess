using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.SilmarillionFigures.Localization;

namespace BattleChess3.SilmarillionFigures
{
    public class ElfOrc : IFigureType
    {
        public static readonly ElfOrc Instance = new ElfOrc();
        public string ShownName => CurrentLocalization.Instance["ElfOrc_Name"];
        public string Description => CurrentLocalization.Instance["ElfOrc_Description"];
        public string UnitName { get; } = $"{nameof(SilmarillionFigureGroup)}.{nameof(ElfOrc)}";
        public FigureTypes UnitTypes { get; } = FigureTypes.Foot;
        public FigureTypes Bonus { get; } = FigureTypes.Nothing;
        public FigureTypes AntiBonus { get; } = FigureTypes.Nothing;
        public double FullHp { get; } = 100;
        public double Attack { get; } = 100;
        public double Defence { get; } = 0;
        public bool MovingAttack { get; } = true;
        public int Cost { get; } = 1;

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/ElfOrc1.png", UriKind.Absolute)},
            {1, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/ElfOrc2.png", UriKind.Absolute)},
        };

        public void AttackAction(ITile from, ITile to, ITile[] board)
            => to.KillFigure(board);

        public void MoveAction(ITile from, ITile to, ITile[] board)
            => from.MoveToPosition(to.Position, board);

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