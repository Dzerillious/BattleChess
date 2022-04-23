using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.CrossFireFigures.Localization;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.CrossFireFigures;

public class Builder : IFigureType
{
    public static readonly Builder Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Builder)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Builder)}_Description"];
    public string UnitName => $"{nameof(CrossFireFigureGroup)}.{nameof(Builder)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 1;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Builder)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Builder)}2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => 0;

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public bool CanAttack(ITile unitTile, ITile targetTile, ITile[] board)
        => false;

    public void AttackAction(ITile unitTile, ITile targetTile, ITile[] board)
        => unitTile.PassTurn();

    public bool CanMove(ITile unitTile, ITile targetTile, ITile[] board)
        => targetTile.IsEmpty();


    public void MoveAction(ITile unitTile, ITile targetTile, ITile[] board)
    {
        var move = targetTile.Position - unitTile.Position;

        MoveFiguresOutsideShield(unitTile, move, board);
        MoveShield(unitTile, move, board);
        unitTile.MoveToTile(targetTile);
    }

    private void MoveShield(ITile sourceTile, Position move, ITile[] board)
    {
        foreach (var shieldPosition in _shieldPositions)
        {
            if (!(sourceTile.Position + shieldPosition).InBoard())
                continue;

            var shieldTile = board[sourceTile.Position + shieldPosition];
            if (shieldTile.Figure.UnitName == Wall.Instance.UnitName &&
                shieldTile.Figure.Owner == sourceTile.Figure.Owner)
            {
                sourceTile.KillFigureWithoutMove(shieldTile);
            }
        }

        foreach (var shieldPosition in _shieldPositions)
        {
            if (!(sourceTile.Position + shieldPosition + move).InBoard())
                continue;

            var shieldTile = board[sourceTile.Position + shieldPosition + move];
            if (shieldTile.IsEmpty())
            {
                shieldTile.CreateFigure(new Figure(sourceTile.Figure.Owner, Wall.Instance, 100));
            }
        }
    }

    private void MoveFiguresOutsideShield(ITile sourceTile, Position move, ITile[] board)
    {
        Position[] movedPositions;
        if (move == new Position(0, 1))
            movedPositions = _upMovedPositions;
        else if (move == new Position(1, 0))
            movedPositions = _rightMovedPositions;
        else if (move == new Position(0, -1))
            movedPositions = _bottomMovedPositions;
        else
            movedPositions = _leftMovedPositions;

        foreach (var movedPosition in movedPositions)
        {
            if (!(sourceTile.Position + movedPosition).InBoard())
                continue;
            if (!(sourceTile.Position + movedPosition + move).InBoard())
                continue;

            var movedTile = board[sourceTile.Position + movedPosition];
            var moveTargetTile = board[sourceTile.Position + movedPosition + move];
            if (movedTile.IsEmpty() ||
                movedTile.Figure.Owner == sourceTile.Figure.Owner ||
                movedTile.Figure.UnitName == Wall.Instance.UnitName)
                continue;

            if (moveTargetTile.IsEmpty())
            {
                movedTile.MoveToTile(moveTargetTile);
            }
            else
            {
                movedTile.KillFigureWithMove(moveTargetTile);
            }
        }
    }

    private readonly Position[] _upMovedPositions =
    {
        new Position(-2, 2),
        new Position(-1, 3),
        new Position(0, 3),
        new Position(1, 3),
        new Position(2, 2),
    };

    private readonly Position[] _rightMovedPositions =
    {
        new Position(2, -2),
        new Position(3, -1),
        new Position(3, 0),
        new Position(3, 1),
        new Position(2, 2),
    };

    private readonly Position[] _bottomMovedPositions =
    {
        new Position(-2, -2),
        new Position(-1, -3),
        new Position(0, -3),
        new Position(1, -3),
        new Position(2, -2),
    };

    private readonly Position[] _leftMovedPositions =
    {
        new Position(-2, -2),
        new Position(-3, -1),
        new Position(-3, 0),
        new Position(-3, 1),
        new Position(-2, 2),
    };

    private readonly Position[] _shieldPositions =
    {
        new Position(-2, 1),
        new Position(-2, 0),
        new Position(-2, -1),

        new Position(2, 1),
        new Position(2, 0),
        new Position(2, -1),

        new Position(1, -2),
        new Position(0, -2),
        new Position(-1, -2),

        new Position(1, 2),
        new Position(0, 2),
        new Position(-1, 2),
    };

    private readonly Position[][] _moveChain =
    {
        new Position[] {(-1, 0)},
        new Position[] {(1, 0)},
        new Position[] {(0, -1)},
        new Position[] {(0, 1)},
    };
    public Position[][] GetMoveChains(Position position, ITile[] board) => _moveChain;
    
    
    private readonly Position[][] _attackChain = { };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
