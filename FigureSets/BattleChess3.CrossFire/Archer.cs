﻿using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.CrossFireFigures.Utilities;
using BattleChess3.CrossFireFigures.Localization;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.CrossFireFigures;

public class Archer : IFigureType
{
    public static readonly Archer Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Archer)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Archer)}_Description"];
    public string UnitName => $"{nameof(CrossFireFigureGroup)}.{nameof(Archer)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 1;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Archer)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Archer)}2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => figureType.DefenceCalculation(this);

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public bool CanAttack(ITile unitTile, ITile targetTile, ITile[] board)
        => CrossFireActionHelper.CanKill(unitTile, targetTile);

    public void AttackAction(ITile unitTile, ITile targetTile, ITile[] board)
        => unitTile.KillFigureWithoutMove(targetTile);

    public bool CanMove(ITile unitTile, ITile targetTile, ITile[] board)
        => targetTile.IsEmpty();

    public void MoveAction(ITile unitTile, ITile targetTile, ITile[] board)
        => unitTile.MoveToTile(targetTile);

    private readonly Position[][] _moveChain = 
    {
        new Position[] {(1, 0)},
        new Position[] {(-1, 0)}
    };
    public Position[][] GetMoveChains(Position position, ITile[] board) => _moveChain;
    
    
    private readonly Position[][] _attackChain =
    {
        new Position[] {(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7)},
        new Position[] {(0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)},
        new Position[] {(-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7)},
    };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
