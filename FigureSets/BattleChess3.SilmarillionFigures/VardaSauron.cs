using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.SilmarillionFigures.Localization;

namespace BattleChess3.SilmarillionFigures
{
    public class VardaSauron : IFigureType
    {
        public static readonly VardaSauron Instance = new VardaSauron();
        public string ShownName => CurrentLocalization.Instance["VardaSauron_Name"];
        public string Description => CurrentLocalization.Instance["VardaSauron_Description"];
        public string UnitName { get; } = $"{nameof(SilmarillionFigureGroup)}.{nameof(VardaSauron)}";
        public FigureTypes UnitTypes { get; } = FigureTypes.Foot;
        public FigureTypes Bonus { get; } = FigureTypes.Nothing;
        public FigureTypes AntiBonus { get; } = FigureTypes.Nothing;
        public double Attack { get; } = 100;
        public double Defence { get; } = 0;
        public bool MovingAttack { get; } = true;
        public int Cost { get; } = 5;

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/VardaSauron1.png", UriKind.Absolute)},
            {1, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/VardaSauron2.png", UriKind.Absolute)},
        };

        public void AttackAction(Tile from, Tile to, Tile[] board)
            => to.KillFigure(board);

        public void MoveAction(Tile from, Tile to, Tile[] board)
            => from.MoveToPosition(to.Position, board);
        
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