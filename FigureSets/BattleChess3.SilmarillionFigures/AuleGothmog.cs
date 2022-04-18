using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.SilmarillionFigures.Localization;

namespace BattleChess3.SilmarillionFigures;

public class AuleGothmog : IFigureType
{
    public static readonly AuleGothmog Instance = new();
    public string ShownName => CurrentLocalization.Instance["AuleGothmog_Name"];
    public string Description => CurrentLocalization.Instance["AuleGothmog_Description"];
    public string UnitName => $"{nameof(SilmarillionFigureGroup)}.{nameof(AuleGothmog)}";
    public FigureTypes UnitTypes => FigureTypes.Foot;
    public FigureTypes Bonus => FigureTypes.Nothing;
    public FigureTypes AntiBonus => FigureTypes.Nothing;
    public double FullHp => 100;
    public double Attack => 100;
    public double Defence => 0;
    public bool MovingAttack => true;
    public int Cost => 3;

    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
    {
        {0, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/AuleGothmog1.png", UriKind.Absolute)},
        {1, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/AuleGothmog2.png", UriKind.Absolute)},
    };

    public void AttackAction(ITile from, ITile to, ITile[] board)
        => to.KillFigure(board);

    public void MoveAction(ITile from, ITile to, ITile[] board)
        => from.MoveToPosition(to.Position, board);

    private readonly Position[][] _moveChain = 
    {
        new Position[] {(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7)},
        new Position[] {(1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7)},
        new Position[] {(-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7)},
        new Position[] {(-1, -1), (-2, -2), (-3, -3), (-4, -4), (-5, -5), (-6, -6), (-7, -7)}
    };
    public Position[][] GetMoveChains(Position position) => _moveChain;
    
    
    private readonly Position[][] _attackChain = 
    {
        new Position[] {(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7)},
        new Position[] {(1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7)},
        new Position[] {(-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7)},
        new Position[] {(-1, -1), (-2, -2), (-3, -3), (-4, -4), (-5, -5), (-6, -6), (-7, -7)}
    };
    public Position[][] GetAttackChains(Position position) => _attackChain;
}
