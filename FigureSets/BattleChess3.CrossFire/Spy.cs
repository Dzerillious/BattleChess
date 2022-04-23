using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.CrossFireFigures.Utilities;
using BattleChess3.CrossFireFigures.Localization;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.CrossFireFigures;

public class Spy : IFigureType
{
    public static readonly Spy Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Spy)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Spy)}_Description"];
    public string UnitName => $"{nameof(CrossFireFigureGroup)}.{nameof(Spy)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 1;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Spy)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Spy)}2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => figureType.DefenceCalculation(this);

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public bool CanAttack(ITile unitTile, ITile targetTile, ITile[] board)
        => CrossFireActionHelper.CanKill(unitTile, targetTile);

    public void AttackAction(ITile unitTile, ITile targetTile, ITile[] board)
        => unitTile.KillFigureWithMove(targetTile);

    public bool CanMove(ITile unitTile, ITile targetTile, ITile[] board)
    {
        if (targetTile.IsEmpty())
        {
            var relative = targetTile.Position - unitTile.Position;
            return Math.Abs(relative.X) <= 1 &&
                Math.Abs(relative.Y) <= 1;
        }

        return targetTile.Figure.Owner.Equals(unitTile.Figure.Owner);
    }

    public void MoveAction(ITile unitTile, ITile targetTile, ITile[] board)
    {
        if (targetTile.IsEmpty())
        {
            unitTile.MoveToTile(targetTile);
        }
        else
        {
            unitTile.SwapWithTile(targetTile);
        }
    }

    public Position[][] GetMoveChains(Position position, ITile[] board)
    {
        var result = new Position[board.Length][];
        for (int i = 0; i < board.Length; i++)
        {
            result[i] = new Position[] { board[i].Position - position };
        }
        return result;
    }
    
    private readonly Position[][] _attackChain = 
    {
        new Position[] {(1, 1)},
        new Position[] {(1, 0)},
        new Position[] {(1, -1)},
        new Position[] {(0, 1)},
        new Position[] {(0, 0)},
        new Position[] {(0, -1)},
        new Position[] {(-1, 1)},
        new Position[] {(-1, 0)},
        new Position[] {(-1, -1)},
    };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
