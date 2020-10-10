using System;
using System.Collections.Generic;
using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.ChessFigures
{
    public class Rook : IFigureType
    {
        public static readonly Rook Instance = new Rook();
        public string ShownName => CurrentLocalization.Instance["Rook_Name"];
        public string UnitName => $"{nameof(ChessFigureGroup)}.{nameof(Rook)}";
        public string GroupName => nameof(ChessFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Object;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 5;
        public string Description => CurrentLocalization.Instance["Rook_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {1, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Rook1.png", UriKind.Absolute)},
            {2, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Rook2.png", UriKind.Absolute)},
        };

        public void AttackAction(Position from, Position to, Tile[] board)
            => board[to].KillFigure(board);

        private readonly Position[][] _moveChain = 
        {
            new Position[] {(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0)}, 
            new Position[] {(0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)},
            new Position[] {(-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0)},
            new Position[] {(0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7)}
        };
        public Position[][] MoveChain(Position position) => _moveChain;
        
        
        private readonly Position[][] _attackChain = 
        {
            new Position[] {(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0)}, 
            new Position[] {(0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)},
            new Position[] {(-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0)},
            new Position[] {(0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7)}
        };
        public Position[][] AttackChain(Position position) => _attackChain;
    }
}