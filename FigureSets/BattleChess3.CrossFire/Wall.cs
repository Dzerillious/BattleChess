using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Localization;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.CrossFireFigures;

public class Wall : IFigureType
{
    public static readonly Wall Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Wall)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Wall)}_Description"];
    public string UnitName => $"{nameof(CrossFireFigureGroup)}.{nameof(Wall)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 1;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Wall)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{nameof(Wall)}2.png", UriKind.Absolute)},
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
        new Position[] {(1, 1)},
        new Position[] {(-1, 1)}
    };
    public Position[][] GetMoveChains(Position position, ITile[] board) => _moveChain;
    
    
    private readonly Position[][] _attackChain = 
    {
        new Position[] {(0, 1)},
        new Position[] {(1, 0)},
        new Position[] {(-1, 0)},
    };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
