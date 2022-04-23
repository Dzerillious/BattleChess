using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.CrossFireFigures.Utilities;
using BattleChess3.DefaultFigures.Localization;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.CrossFireFigures;

public class Knight : IFigureType
{
    public static readonly Knight Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Knight)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Knight)}_Description"];
    public string UnitName => $"{nameof(CrossFireFigureGroup)}.{nameof(Knight)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 1;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Knight)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Knight)}2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => figureType.DefenceCalculation(this);

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public bool CanAttack(ITile unitTile, ITile targetTile, ITile[] board)
        => CrossFireActionHelper.CanKill(unitTile, targetTile);

    public void AttackAction(ITile unitTile, ITile targetTile, ITile[] board)
    {
        var move = targetTile.Position - unitTile.Position;

        if (Math.Abs(move.X) <= 1 &&
            Math.Abs(move.Y) <= 1)
        {
            unitTile.KillFigureWithMove(targetTile);
        }
        else if (Math.Abs(move.X) <= 2 &&
            Math.Abs(move.Y) <= 2)
        {
            var smallMove = (Math.Sign(move.X), Math.Sign(move.Y));
            unitTile.KillFigureWithoutMove(board[unitTile.Position + smallMove]);
            unitTile.KillFigureWithMove(targetTile);
        }
        else
        {
            var smallMove = (Math.Sign(move.X), Math.Sign(move.Y));
            unitTile.KillFigureWithoutMove(board[unitTile.Position + smallMove]);
            unitTile.KillFigureWithoutMove(board[unitTile.Position + smallMove + smallMove]);
            unitTile.KillFigureWithMove(targetTile);
        }
    }

    public bool CanMove(ITile unitTile, ITile targetTile, ITile[] board)
        => targetTile.IsEmpty();

    public void MoveAction(ITile unitTile, ITile targetTile, ITile[] board)
        => unitTile.MoveToTile(targetTile);

    private readonly Position[][] _moveChain =
    {
        new Position[] {(-2, -1)},
        new Position[] {(-2, 1)},
        new Position[] {(-1, -2)},
        new Position[] {(-1, 2)},
        new Position[] {(1, -2)},
        new Position[] {(1, 2)},
        new Position[] {(2, -1)},
        new Position[] {(2, 1)},
    };
    public Position[][] GetMoveChains(Position position, ITile[] board) => _moveChain;
    
    
    private readonly Position[][] _attackChain =
    {
        new Position[] {(-1, -1)},
        new Position[] {(-1, 0)},
        new Position[] {(-1, 1)},
        new Position[] {(0, -1)},
        new Position[] {(0, 0)},
        new Position[] {(0, 1)},
        new Position[] {(1, -1)},
        new Position[] {(1, 0)},
        new Position[] {(1, 1)},

        new Position[] {(-2, -2)},
        new Position[] {(-2, 0)},
        new Position[] {(-2, 2)},
        new Position[] {(0, -2)},
        new Position[] {(0, 2)},
        new Position[] {(2, -2)},
        new Position[] {(2, 0)},
        new Position[] {(2, 2)},

        new Position[] {(-3, -3)},
        new Position[] {(-3, 0)},
        new Position[] {(-3, 3)},
        new Position[] {(0, -3)},
        new Position[] {(0, 3)},
        new Position[] {(3, -3)},
        new Position[] {(3, 0)},
        new Position[] {(3, 3)},
    };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
