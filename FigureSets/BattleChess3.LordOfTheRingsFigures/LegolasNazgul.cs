using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures;

public class LegolasNazgul : IFigureType
{
    public static readonly LegolasNazgul Instance = new();
    public string ShownName => CurrentLocalization.Instance[$"{nameof(LegolasNazgul)}_Name"];
    public string Description => CurrentLocalization.Instance[$"{nameof(LegolasNazgul)}_Description"];
    public string UnitName => $"{nameof(LordOfTheRingsFigureGroup)}.{nameof(LegolasNazgul)}";
    public FigureTypes UnitType => FigureTypes.Foot;
    public double FullHp => 100;
    public double Attack => 100;
    public int Cost => 5;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {1, new Uri($"pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/{nameof(LegolasNazgul)}1.png", UriKind.Absolute)},
        {2, new Uri($"pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/{nameof(LegolasNazgul)}2.png", UriKind.Absolute)},
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
        => targetTile.IsEmpty();

    public void MoveAction(ITile unitTile, ITile targetTile, ITile[] board)
        => unitTile.MoveToTile(targetTile);

    private readonly Position[][] _moveChain = 
    {
        new Position[] {(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0)}, 
        new Position[] {(0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)},
        new Position[] {(-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0)},
        new Position[] {(0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7)}
    };
    public Position[][] GetMoveChains(Position position, ITile[] board) => _moveChain;
    
    
    private readonly Position[][] _attackChain = 
    {
        new Position[] {(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0)}, 
        new Position[] {(0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)},
        new Position[] {(-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0)},
        new Position[] {(0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7)}
    };
    public Position[][] GetAttackChains(Position position, ITile[] board) => _attackChain;
}
