using System;
using System.Collections.Generic;
using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.ChessFigures;

public class Knight : IFigureType
{
    public static readonly Knight Instance = new();
    public string ShownName => CurrentLocalization.Instance["Knight_Name"];
    public string Description => CurrentLocalization.Instance["Knight_Description"];
    public string UnitName => $"{nameof(ChessFigureGroup)}.{nameof(Knight)}";
    public FigureTypes UnitType => FigureTypes.Mount;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 3;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Knight1.png", UriKind.Absolute)},
        {2, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Knight2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => figureType.DefenceCalculation(this);

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public void AttackAction(ITile from, ITile to, ITile[] board)
        => board.KillFigureWithMove(from, to);

    public void MoveAction(ITile from, ITile to, ITile[] board)
        => board.MoveToPosition(from, to.Position);

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
