using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.CrossFireFigures.Utilities;
using BattleChess3.DefaultFigures.Localization;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.CrossFireFigures;

public class Bomber : IFigureType
{
    public static readonly Bomber Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Bomber)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Bomber)}_Description"];
    public string UnitName => $"{nameof(CrossFireFigureGroup)}.{nameof(Bomber)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 1;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Bomber)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Bomber)}2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => figureType.DefenceCalculation(this);

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public bool CanAttack(ITile unitTile, ITile targetTile, ITile[] board)
        => CrossFireActionHelper.CanKill(unitTile, targetTile);

    public void AttackAction(ITile unitTile, ITile targetTile, ITile[] board)
    {
        foreach (var explosionPosition in _bombChain)
        {
            if (!(targetTile.Position + explosionPosition).InBoard())
                continue;

            var explosionTile = board[targetTile.Position + explosionPosition];
            unitTile.KillFigureWithoutMove(explosionTile);
        }
    }
    public bool CanMove(ITile unitTile, ITile targetTile, ITile[] board)
        => targetTile.IsEmpty();

    public void MoveAction(ITile unitTile, ITile targetTile, ITile[] board)
    {
        foreach (var explosionPosition in _bombChain)
        {
            if (!(targetTile.Position + explosionPosition).InBoard())
                continue;

            var explosionTile = board[targetTile.Position + explosionPosition];
            unitTile.KillFigureWithoutMove(explosionTile);
        }

        unitTile.MoveToTile(targetTile);
    }

    private readonly Position[][] _moveChain =
    {
        new Position[] {(-2, -2)},
        new Position[] {(-2, 2)},
        new Position[] {(2, -2)},
        new Position[] {(2, 2)},
    };
    public Position[][] GetMoveChains(Position position, ITile[] board) => _attackChain;
    
    private readonly Position[] _bombChain =
    {
        (1, 1),
        (1, 0),
        (1, -1),
        (0, 1),
        (0, -1),
        (-1, 1),
        (-1, 0),
        (-1, -1),
    };

    private readonly Position[][] _attackChain =
    {
        new Position[] {(-2, -2)},
        new Position[] {(-2, 2)},
        new Position[] {(2, -2)},
        new Position[] {(2, 2)},
    };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
