using System;
using System.Collections.Generic;

namespace BattleChess3.Core.Model.Figures;

public class NoneFigure : IFigureType
{
    public static NoneFigure Instance { get; } = new();
    
    public string ShownName { get; } = string.Empty;
    public string Description { get; } = string.Empty;
    public string UnitName { get; } = string.Empty;
    public FigureTypes UnitType { get; } = FigureTypes.Nothing;
    public double FullHp { get; } = 0;
    public double Attack { get; } = 0;
    public int Cost { get; } = 0;
    public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>();

    public bool CanAttack(ITile from, ITile to, ITile[] board)
        => false;

    public void AttackAction(ITile from, ITile to, ITile[] board)
    {
    }

    public bool CanMove(ITile from, ITile tile, ITile[] board)
        => false;

    public void MoveAction(ITile from, ITile to, ITile[] board)
    {
    }

    public Position[][] GetMoveChains(Position from, ITile[] board) => Array.Empty<Position[]>();

    public Position[][] GetAttackChains(Position from, ITile[] board) => Array.Empty<Position[]>();

    public double AttackCalculation(IFigureType figureType)
        => 0;

    public double DefenceCalculation(IFigureType figureType)
        => 0;
}
