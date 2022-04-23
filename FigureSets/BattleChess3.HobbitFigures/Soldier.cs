using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.HobbitFigures.Localization;

namespace BattleChess3.HobbitFigures;

public class Soldier : IFigureType
{
    public static readonly Soldier Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(Soldier)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(Soldier)}_Description"];
    public string UnitName => $"{nameof(HobbitFigureGroup)}.{nameof(Soldier)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 1;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.HobbitFigures;component/Images/{nameof(Soldier)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.HobbitFigures;component/Images/{nameof(Soldier)}2.png", UriKind.Absolute)},
    };

    public double AttackCalculation(IFigureType figureType)
        => figureType.DefenceCalculation(this);

    public double DefenceCalculation(IFigureType figureType)
        => figureType.Attack;

    public bool CanAttack(ITile from, ITile to, ITile[] board)
        => to.Figure.Hp - from.Figure.AttackCalculation(to.Figure) <= 0;

    public void AttackAction(ITile from, ITile to, ITile[] board)
        => board.KillFigureWithMove(from, to);

    public bool CanMove(ITile from, ITile tile, ITile[] board)
        => tile.Figure.IsEmpty();

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
