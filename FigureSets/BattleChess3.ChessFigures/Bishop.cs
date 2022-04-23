using System;
using System.Collections.Generic;
using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;

namespace BattleChess3.ChessFigures;

public class Bishop : IFigureType
{
    public static readonly Bishop Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Bishop)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Bishop)}_Description"];
    public string UnitName => $"{nameof(ChessFigureGroup)}.{nameof(Bishop)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 3;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.ChessFigures;component/Images/{nameof(Bishop)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.ChessFigures;component/Images/{nameof(Bishop)}2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => figureType.DefenceCalculation(this);

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public void AttackAction(ITile unit, ITile target, ITile[] board)
        => board.KillFigureWithMove(unit, target);

    public void MoveAction(ITile unit, ITile target, ITile[] board)
        => board.MoveToPosition(unit, target.Position);

    private readonly Position[][] _moveChain = 
    {
        new Position[] {(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7)},
        new Position[] {(1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7)},
        new Position[] {(-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7)},
        new Position[] {(-1, -1), (-2, -2), (-3, -3), (-4, -4), (-5, -5), (-6, -6), (-7, -7)}
    };
    public Position[][] GetMoveChains(Position position, ITile[] board) => _moveChain;
    
    
    private readonly Position[][] _attackChain = 
    {
        new Position[] {(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7)},
        new Position[] {(1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7)},
        new Position[] {(-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7)},
        new Position[] {(-1, -1), (-2, -2), (-3, -3), (-4, -4), (-5, -5), (-6, -6), (-7, -7)}
    };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
