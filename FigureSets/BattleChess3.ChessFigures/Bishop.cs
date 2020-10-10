using System;
using System.Collections.Generic;
using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.ChessFigures
{
    public class Bishop : IFigureType
    {
        public static readonly Bishop Instance = new Bishop();
        public string ShownName => CurrentLocalization.Instance["Bishop_Name"];
        public string UnitName => $"{nameof(ChessFigureGroup)}.{nameof(Bishop)}";
        public string GroupName => nameof(ChessFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;
        public string Description => CurrentLocalization.Instance["Bishop_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {1, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Bishop1.png", UriKind.Absolute)},
            {2, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Bishop2.png", UriKind.Absolute)},
        };

        public void AttackAction(Position from, Position to, Tile[] board)
            => board[to].KillFigure(board);

        private readonly Position[][] _moveChain = 
        {
            new Position[] {(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7)},
            new Position[] {(1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7)},
            new Position[] {(-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7)},
            new Position[] {(-1, -1), (-2, -2), (-3, -3), (-4, -4), (-5, -5), (-6, -6), (-7, -7)}
        };
        public Position[][] MoveChain(Position position) => _moveChain;
        
        
        private readonly Position[][] _attackChain = 
        {
            new Position[] {(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7)},
            new Position[] {(1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7)},
            new Position[] {(-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7)},
            new Position[] {(-1, -1), (-2, -2), (-3, -3), (-4, -4), (-5, -5), (-6, -6), (-7, -7)}
        };
        public Position[][] AttackChain(Position position) => _attackChain;
    }
}