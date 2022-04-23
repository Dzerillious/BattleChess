using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.CrossFireFigures.Utilities;
using BattleChess3.CrossFireFigures.Localization;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.CrossFireFigures;

public class Ninja : IFigureType
{
    public static readonly Ninja Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Ninja)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Ninja)}_Description"];
    public string UnitName => $"{nameof(CrossFireFigureGroup)}.{nameof(Ninja)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 1;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Ninja)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Ninja)}2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => figureType.DefenceCalculation(this);

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public bool CanAttack(ITile unitTile, ITile targetTile, ITile[] board)
    {
        var move = targetTile.Position - unitTile.Position;

        if (move == new Position(0, 2) &&
            board[unitTile.Position + new Position(0, 1)].IsEmpty())
        {
            return false;
        }
        else
        {
            return CrossFireActionHelper.CanKill(unitTile, targetTile);
        }
    }

    public void AttackAction(ITile unitTile, ITile targetTile, ITile[] board)
    {
        if (targetTile.Position.Y == 7)
        {
            unitTile.KillFigureWithoutMove(targetTile);
            targetTile.CreateFigure(new Figure(unitTile.Figure.Owner, Bomber.Instance));
            unitTile.KillFigureWithoutMove(unitTile);
        }
        else
        {
            unitTile.KillFigureWithMove(targetTile);
        }
    }

    public bool CanMove(ITile unitTile, ITile targetTile, ITile[] board)
    {
        var move = targetTile.Position - unitTile.Position; 
        
        if (move == new Position(0, 2) &&
             board[unitTile.Position + new Position(0, 1)].IsEmpty())
        {
            return false;
        }
        else
        {
            return targetTile.IsEmpty();
        }
    }

    public void MoveAction(ITile unitTile, ITile targetTile, ITile[] board)
    {
        if (targetTile.Position.Y == 7)
        {
            targetTile.CreateFigure(new Figure(unitTile.Figure.Owner, Bomber.Instance));
            unitTile.KillFigureWithoutMove(unitTile);
        }
        else
        {
            unitTile.MoveToTile(targetTile);
        }
    }

    private readonly Position[][] _moveChain = 
    {
        new Position[] {(1, 1)},
        new Position[] {(0, 2)},
        new Position[] {(-1, 1)}
    };
    public Position[][] GetMoveChains(Position position, ITile[] board) => _moveChain;
    
    
    private readonly Position[][] _attackChain = 
    {
        new Position[] {(0, 1)},
        new Position[] {(0, 2)},
        new Position[] {(1, 0)},
        new Position[] {(-1, 0)},
    };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
