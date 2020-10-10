using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Localization;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.DefaultFigures
{
    public class Ninja : IFigureType
    {
        public static readonly Ninja Instance = new Ninja();
        public string ShownName => CurrentLocalization.Instance["Ninja_Name"];
        public string Description => CurrentLocalization.Instance["Ninja_Description"];
        public string UnitName { get; } = $"{nameof(DefaultFigureGroup)}.{nameof(Ninja)}";
        public FigureTypes UnitTypes { get; } = FigureTypes.Foot;
        public FigureTypes Bonus { get; } = FigureTypes.Foot;
        public FigureTypes AntiBonus { get; } = FigureTypes.Mount;
        public double Attack { get; } = 50;
        public double Defence { get; } = 0;
        public bool MovingAttack { get; } = true;
        public int Cost { get; } = 1;

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.DefaultFigures;component/Images/Ninja1.png", UriKind.Absolute)},
            {1, new Uri("pack://application:,,,/BattleChess3.DefaultFigures;component/Images/Ninja2.png", UriKind.Absolute)},
        };

        public void AttackAction(Tile from, Tile to, Tile[] board)
            => to.KillFigure(board);

        public void MoveAction(Tile from, Tile to, Tile[] board)
            => from.MoveToPosition(to.Position, board);

        private readonly Position[][] _moveChain = 
        {
            new Position[] {(1, 1)},
            new Position[] {(1, -1)}
        };
        public Position[][] GetMoveChains(Position position) => _moveChain;
        
        
        private readonly Position[][] _attackChain = 
        {
            new Position[] {(1, 0)},
            new Position[] {(0, 1)},
            new Position[] {(0, -1)},
        };
        public Position[][] GetAttackChains(Position position) => _attackChain;
    }
}