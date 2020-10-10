using System;
using System.Collections.Generic;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures
{
    public class MerryTroll : IFigureType
    {
        public static readonly MerryTroll Instance = new MerryTroll();
        public string ShownName => CurrentLocalization.Instance["MerryTroll_Name"];
        public string UnitName => $"{nameof(LordOfTheRingsFigureGroup)}.{nameof(MerryTroll)}";
        public string GroupName => nameof(LordOfTheRingsFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;
        public string Description => CurrentLocalization.Instance["MerryTroll_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {1, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/MerryTroll1.png", UriKind.Absolute)},
            {2, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/MerryTroll2.png", UriKind.Absolute)},
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