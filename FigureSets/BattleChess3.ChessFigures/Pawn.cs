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
    public string ShownName => CurrentLocalization.Instance["Pawn_Name"];
    public string Description => CurrentLocalization.Instance["Pawn_Description"];
    public string UnitName => $"{nameof(ChessFigureGroup)}.{nameof(Pawn)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 1;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Pawn1.png", UriKind.Absolute)},
        {2, new Uri("pack://application:,,,/BattleChess3.ChessFigures;component/Images/Pawn2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => figureType.DefenceCalculation(this);

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public void AttackAction(ITile from, ITile to, ITile[] board)
        => board.KillFigureWithMove(from, to);

    public void MoveAction(ITile from, ITile to, ITile[] board)
        => board.MoveToPosition(from, to.Position);

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
