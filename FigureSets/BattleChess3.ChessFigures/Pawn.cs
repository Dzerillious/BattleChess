using System;
using System.Collections.Generic;
using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.ChessFigures;

public class Pawn : IFigureType
{
    public static readonly Pawn Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Pawn)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Pawn)}_Description"];
    public string UnitName => $"{nameof(ChessFigureGroup)}.{nameof(Pawn)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 1;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.ChessFigures;component/Images/{nameof(Pawn)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.ChessFigures;component/Images/{nameof(Pawn)}2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => figureType.DefenceCalculation(this);

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public bool CanAttack(ITile unitTile, ITile targetTile, ITile[] board)
        => unitTile.CanKill(targetTile);

    public void AttackAction(ITile unitTile, ITile targetTile, ITile[] board)
    {
        if (targetTile.Position.Y == 7)
        {
            unitTile.KillFigureWithoutMove(targetTile);
            targetTile.CreateFigure(new Figure(unitTile.Figure.Owner, Queen.Instance));
            unitTile.KillFigureWithoutMove(unitTile);
        }
        else
        {
            unitTile.KillFigureWithMove(targetTile);
        }
    }

    public bool CanMove(ITile unitTile, ITile targetTile, ITile[] board)
        => targetTile.IsEmpty();

    public void MoveAction(ITile unitTile, ITile targetTile, ITile[] board)
    {
        if (targetTile.Position.Y == 7)
        {
            targetTile.CreateFigure(new Figure(unitTile.Figure.Owner, Queen.Instance));
            unitTile.KillFigureWithoutMove(unitTile);
        }
        else
        {
            unitTile.MoveToTile(targetTile);
        }
    }

    private readonly Position[][] _firstMoveChain = 
    {
        new Position[] {(0, 1), (0, 2)},
    };
    private readonly Position[][] _moveChain = 
    {
        new Position[] {(0, 1)},
    };
    public Position[][] GetMoveChains(Position position, ITile[] board)
        => position.Y == 1 ? _firstMoveChain : _moveChain;


    private readonly Position[][] _attackChain = 
    {
        new Position[] {(1, 1)},
        new Position[] {(-1, 1)},
    };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
