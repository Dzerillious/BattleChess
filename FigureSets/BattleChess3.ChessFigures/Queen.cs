﻿using System;
using System.Collections.Generic;
using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.ChessFigures;

public class Queen : IFigureType
{
    public static readonly Queen Instance = new();
    public string ShownName => CurrentLocalization.Instance["Queen_Name"];
    public string Description => CurrentLocalization.Instance["Queen_Description"];
    public string UnitName => $"{nameof(ChessFigureGroup)}.{nameof(Queen)}";
    public FigureTypes UnitTypes => FigureTypes.Special;
    public FigureTypes Bonus => FigureTypes.Nothing;
    public FigureTypes AntiBonus => FigureTypes.Nothing;
    public double FullHp => 100;
    public double Attack => 100;
    public double Defence => 0;
    public bool MovingAttack => true;
    public int Cost => 9;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Queen1.png", UriKind.Absolute)},
        {2, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Queen2.png", UriKind.Absolute)},
    };

    public void AttackAction(ITile from, ITile to, ITile[] board)
        => to.KillFigure(board);

    public void MoveAction(ITile from, ITile to, ITile[] board)
        => from.MoveToPosition(to.Position, board);

    private readonly Position[][] _moveChain = 
    {
        new Position[] {(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0)}, 
        new Position[] {(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7)},
        new Position[] {(0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)},
        new Position[] {(1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7)},
        new Position[] {(-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7)},
        new Position[] {(-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0)},
        new Position[] {(-1, -1), (-2, -2), (-3, -3), (-4, -4), (-5, -5), (-6, -6), (-7, -7)},
        new Position[] {(0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7)}
    };
    public Position[][] GetMoveChains(Position position) => _moveChain;
    
    
    private readonly Position[][] _attackChain = 
    {
        new Position[] {(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0)}, 
        new Position[] {(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7)},
        new Position[] {(0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)},
        new Position[] {(1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7)},
        new Position[] {(-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7)},
        new Position[] {(-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0)},
        new Position[] {(-1, -1), (-2, -2), (-3, -3), (-4, -4), (-5, -5), (-6, -6), (-7, -7)},
        new Position[] {(0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7)}
    };
    public Position[][] GetAttackChains(Position position) => _attackChain;
}
