using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.CrossFireFigures;

public class Wall : IFigureType
{
    public static readonly Wall Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Wall)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Wall)}_Description"];
    public string UnitName => $"{nameof(CrossFireFigureGroup)}.{nameof(Wall)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 1;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Wall)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Wall)}2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => 0;

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public bool CanAttack(ITile from, ITile to, ITile[] board)
        => false;

    public void AttackAction(ITile from, ITile to, ITile[] board)
    {
    }

    public bool CanMove(ITile from, ITile tile, ITile[] board)
        => false;

    public void MoveAction(ITile from, ITile to, ITile[] board)
    {
    }

    private readonly Position[][] _moveChain = {};
    public Position[][] GetMoveChains(Position position, ITile[] board) => _moveChain;
    
    
    private readonly Position[][] _attackChain = {};
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
