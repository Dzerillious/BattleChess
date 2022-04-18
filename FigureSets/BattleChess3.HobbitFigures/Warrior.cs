using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.HobbitFigures.Localization;

namespace BattleChess3.HobbitFigures;

public class Warrior : IFigureType
{
    public static readonly Warrior Instance = new();
    public string ShownName => CurrentLocalization.Instance["Warrior_Name"];
    public string Description => CurrentLocalization.Instance["Warrior_Description"];
    public string UnitName => $"{nameof(HobbitFigureGroup)}.{nameof(Warrior)}";
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
        {0, new Uri("pack://application:,,,/BattleChess3.HobbitFigures;component/Images/Warrior1.png", UriKind.Absolute)},
        {1, new Uri("pack://application:,,,/BattleChess3.HobbitFigures;component/Images/Warrior2.png", UriKind.Absolute)},
    };

    public void AttackAction(ITile from, ITile to, ITile[] board)
        => to.KillFigure(board);

    public void MoveAction(ITile from, ITile to, ITile[] board)
        => from.MoveToPosition(to.Position, board);

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
    public Position[][] GetMoveChains(Position position) => _moveChain;
    
    
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
    public Position[][] GetAttackChains(Position position) => _attackChain;
}
