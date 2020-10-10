using System;
using System.Collections.Generic;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.SilmarillionFigures.Localization;

namespace BattleChess3.SilmarillionFigures
{
    public class UlmoAncalagon : IFigureType
    {
        public static readonly UlmoAncalagon Instance = new UlmoAncalagon();
        public string ShownName => CurrentLocalization.Instance["UlmoAncalagon_Name"];
        public string UnitName => $"{nameof(SilmarillionFigureGroup)}.{nameof(UlmoAncalagon)}";
        public string GroupName => nameof(SilmarillionFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 9;
        public string Description => CurrentLocalization.Instance["UlmoAncalagon_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {1, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/UlmoAncalagon1.png", UriKind.Absolute)},
            {2, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/UlmoAncalagon2.png", UriKind.Absolute)},
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