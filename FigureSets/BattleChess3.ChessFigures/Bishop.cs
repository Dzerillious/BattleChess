using System;
using System.Collections.Generic;
using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.ChessFigures
{
    public class Bishop : IFigureType
    {
        public static readonly Bishop Instance = new Bishop();
        public string ShownName => CurrentLocalization.Instance["Bishop_Name"];
        public string Description => CurrentLocalization.Instance["Bishop_Description"];
        public string UnitName { get; } = $"{nameof(ChessFigureGroup)}.{nameof(Bishop)}";
        public FigureTypes UnitTypes { get; } = FigureTypes.Foot;
        public FigureTypes Bonus { get; } = FigureTypes.Nothing;
        public FigureTypes AntiBonus { get; } = FigureTypes.Nothing;
        public double Attack { get; } = 100;
        public double Defence { get; } = 0;
        public bool MovingAttack { get; } = true;
        public int Cost { get; } = 3;

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Bishop1.png", UriKind.Absolute)},
            {1, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Bishop2.png", UriKind.Absolute)},
        };

        public void AttackAction(Tile from, Tile to, Tile[] board)
            => to.KillFigure(board);

        public void MoveAction(Tile from, Tile to, Tile[] board)
            => from.MoveToPosition(to.Position, board);

        private readonly Position[][] _moveChain = 
        {
            new Position[] {(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7)},
            new Position[] {(1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7)},
            new Position[] {(-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7)},
            new Position[] {(-1, -1), (-2, -2), (-3, -3), (-4, -4), (-5, -5), (-6, -6), (-7, -7)}
        };
        public Position[][] GetMoveChains(Position position) => _moveChain;
        
        
        private readonly Position[][] _attackChain = 
        {
            new Position[] {(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7)},
            new Position[] {(1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7)},
            new Position[] {(-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7)},
            new Position[] {(-1, -1), (-2, -2), (-3, -3), (-4, -4), (-5, -5), (-6, -6), (-7, -7)}
        };
        public Position[][] GetAttackChains(Position position) => _attackChain;
    }
}