using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.DefaultFigures;

public class Palm : IFigureType
{
    public static readonly Palm Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Palm)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Palm)}_Description"];
    public string UnitName => $"{nameof(DefaultFigureGroup)}.{nameof(Palm)}";
    public FigureTypes UnitType => FigureTypes.Object;
    public double FullHp => 100;
    public double Attack => 0;
    public int Cost => 0;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {0, new Uri($"pack://application:,,,/BattleChess3.DefaultFigures;component/Images/{nameof(Palm)}0.png", UriKind.Absolute)},
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

    private readonly Position[][] _moveChain = { };
    public Position[][] GetMoveChains(Position position, ITile[] board) => _moveChain;
    
    
    private readonly Position[][] _attackChain = { };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
