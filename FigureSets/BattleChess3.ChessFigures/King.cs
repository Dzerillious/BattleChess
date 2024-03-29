﻿using System;
using System.Collections.Generic;
using BattleChess3.DisneyFigures.Localization;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.DisneyFigures;

public class King : IFigureType
{
    public static readonly King Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(King)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(King)}_Description"];
    public string UnitName => $"{nameof(DisneyFigureGroup)}.{nameof(King)}";
    public FigureTypes UnitType => FigureTypes.Special;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 0;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.ChessFigures;component/Images/{nameof(King)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.ChessFigures;component/Images/{nameof(King)}2.png", UriKind.Absolute)},
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
    {
        var move = targetTile.Position - unitTile.Position;

        if (Math.Abs(move.X) <= 1 &&
            Math.Abs(move.Y) <= 1)
        {
            return targetTile.IsEmpty();
        }

        if (unitTile.Position != new Position(4, 0))
            return false;

        if (targetTile.Position == new Position(0, 0))
        {
            return targetTile.Figure.UnitName == Rook.Instance.UnitName &&
                targetTile.Figure.Owner == unitTile.Figure.Owner &&
                board[new Position(1, 0)].IsEmpty() &&
                board[new Position(2, 0)].IsEmpty() &&
                board[new Position(3, 0)].IsEmpty();
        }
        else if (targetTile.Position == new Position(7, 0))
        {
            return targetTile.Figure.UnitName == Rook.Instance.UnitName &&
                targetTile.Figure.Owner == unitTile.Figure.Owner &&
                board[new Position(5, 0)].IsEmpty() &&
                board[new Position(6, 0)].IsEmpty();
        }
        else
        {
            return false;
        }
    }

    public void MoveAction(ITile unitTile, ITile targetTile, ITile[] board)
    {
        var move = targetTile.Position - unitTile.Position;

        if (Math.Abs(move.X) <= 1 &&
            Math.Abs(move.Y) <= 1)
        {
            unitTile.MoveToTile(targetTile);
        }
        else if (targetTile.Position == new Position(0, 0))
        {
            unitTile.MoveToTile(board[new Position(2, 0)]);
            targetTile.MoveToTile(board[new Position(3, 0)]);
        }
        else if (targetTile.Position == new Position(7, 0))
        {
            unitTile.MoveToTile(board[new Position(6, 0)]);
            targetTile.MoveToTile(board[new Position(5, 0)]);
        }
        else
        {
            throw new ArgumentException("Ivalid target position");
        }
    }

    public Position[][] GetMoveChains(Position position, ITile[] board)
    {
        var moveChains = new List<Position[]>
        {
            new Position[] {(1, 1)},
            new Position[] {(1, 0)},
            new Position[] {(1, -1)},
            new Position[] {(0, 1)},
            new Position[] {(0, -1)},
            new Position[] {(-1, 1)},
            new Position[] {(-1, 0)},
            new Position[] {(-1, -1)},
        };

        if (position == new Position(4, 0))
        {
            moveChains.Add(new Position[] { new Position(0, 0) - position });
            moveChains.Add(new Position[] { new Position(7, 0) - position });
        }

        return moveChains.ToArray();
    }
    
    
    private readonly Position[][] _attackChain = 
    {
        new Position[] {(1, 1)},
        new Position[] {(1, 0)},
        new Position[] {(1, -1)},
        new Position[] {(0, 1)},
        new Position[] {(0, -1)},
        new Position[] {(-1, 1)},
        new Position[] {(-1, 0)},
        new Position[] {(-1, -1)},
    };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
