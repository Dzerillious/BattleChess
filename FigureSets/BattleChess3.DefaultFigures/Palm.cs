﻿using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.DefaultFigures;

public class Palm : IFigureType
{
    public static readonly Palm Instance = new();
    public string ShownName => CurrentLocalization.Instance["Palm_Name"];
    public string Description => CurrentLocalization.Instance["Palm_Description"];
    public string UnitName => $"{nameof(DefaultFigureGroup)}.{nameof(Palm)}";
    public FigureTypes UnitTypes => FigureTypes.Object;
    public FigureTypes Bonus => FigureTypes.Nothing;
    public FigureTypes AntiBonus => FigureTypes.Nothing;
    public double FullHp => 100;
    public double Attack => 0;
    public double Defence => -50;
    public bool MovingAttack => false;
    public int Cost => 0;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {0, new Uri("pack://application:,,,/BattleChess3.DefaultFigures;component/Images/Palm0.png", UriKind.Absolute)},
    };

    public void AttackAction(ITile from, ITile to, ITile[] board)
    {
    }

    public void MoveAction(ITile from, ITile to, ITile[] board)
    {
    }

    private readonly Position[][] _moveChain = { };
    public Position[][] GetMoveChains(Position position) => _moveChain;
    
    
    private readonly Position[][] _attackChain = { };
    public Position[][] GetAttackChains(Position position) => _attackChain;
}
