using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures;

public class FrodoGollum : IFigureType
{
    public static readonly FrodoGollum Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(FrodoGollum)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(FrodoGollum)}_Description"];
    public string UnitName => $"{nameof(LordOfTheRingsFigureGroup)}.{nameof(FrodoGollum)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 3;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/{nameof(FrodoGollum)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/{nameof(FrodoGollum)}2.png", UriKind.Absolute)},
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
