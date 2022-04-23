using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.SilmarillionFigures.Localization;

namespace BattleChess3.SilmarillionFigures;

public class IrmoUngoliant : IFigureType
{
    public static readonly IrmoUngoliant Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(IrmoUngoliant)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(IrmoUngoliant)}_Description"];
    public string UnitName => $"{nameof(SilmarillionFigureGroup)}.{nameof(IrmoUngoliant)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 3;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/{nameof(IrmoUngoliant)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/{nameof(IrmoUngoliant)}2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => figureType.DefenceCalculation(this);

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public bool CanAttack(ITile unitTile, ITile targetTile, ITile[] board)
        => unitTile.CanKill(targetTile);

    public void AttackAction(ITile unitTile, ITile targetTile, ITile[] board)
        => unitTile.KillFigureWithMove(targetTile);

    public bool CanMove(ITile unitTile, ITile targetTile, ITile[] board)
        => targetTile.IsEmpty();

    public void MoveAction(ITile unitTile, ITile targetTile, ITile[] board)
        => unitTile.MoveToTile(targetTile);

    private readonly Position[][] _moveChain = 
    {
        new Position[] {(-2, 1)},
        new Position[] {(-2, -1)},
        new Position[] {(2, 1)},
        new Position[] {(2, -1)},
        new Position[] {(-1, -2)},
        new Position[] {(1, -2)},
        new Position[] {(-1, 2)},
        new Position[] {(1, 2)},
    };
    public Position[][] GetMoveChains(Position position, ITile[] board) => _moveChain;
    
    
    private readonly Position[][] _attackChain = 
    {
        new Position[] {(-2, 1)},
        new Position[] {(-2, -1)},
        new Position[] {(2, 1)},
        new Position[] {(2, -1)},
        new Position[] {(-1, -2)},
        new Position[] {(1, -2)},
        new Position[] {(-1, 2)},
        new Position[] {(1, 2)},
    };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
