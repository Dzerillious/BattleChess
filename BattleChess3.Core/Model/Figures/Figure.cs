using System;
using System.Collections.Generic;

namespace BattleChess3.Core.Model.Figures;

public class Figure : IFigureType
{
    public static readonly Figure None = new Figure(Player.Neutral, NoneFigure.Instance, 0);
    
    public Player Owner { get; }
    public IFigureType FigureType { get; set; }
    public double Hp { get; set; }
    public Uri ImageUri => FigureType.ImageUris[Owner.Id];

    public string ShownName => FigureType.ShownName;
    public string Description => FigureType.Description;
    public string UnitName => FigureType.UnitName;
    public double FullHp => FigureType.FullHp;
    public double Attack => FigureType.Attack;
    public FigureTypes UnitType => FigureType.UnitType;
    public int Cost => FigureType.Cost;
    public Dictionary<int, Uri> ImageUris => FigureType.ImageUris;

    public Figure(Player owner, IFigureType figureType, double hp)
    {
        Hp = hp;
        Owner = owner;
        FigureType = figureType;
    }

    public double AttackCalculation(IFigureType figureType)
        => FigureType.AttackCalculation(figureType);

    public double DefenceCalculation(IFigureType figureType)
        => FigureType.DefenceCalculation(figureType);

    public bool CanAttack(ITile from, ITile to, ITile[] board)
        => FigureType.CanAttack(from, to, board);

    public void AttackAction(ITile from, ITile to, ITile[] board)
        => FigureType.AttackAction(from, to, board);

    public bool CanMove(ITile from, ITile to, ITile[] board)
        => FigureType.CanMove(from, to, board);

    public void MoveAction(ITile from, ITile to, ITile[] board)
        => FigureType.MoveAction(from, to, board);

    public Position[][] GetMoveChains(Position from, ITile[] board)
        => FigureType.GetMoveChains(from, board);

    public Position[][] GetAttackChains(Position from, ITile[] board)
        => FigureType.GetAttackChains(from, board);

    public override string ToString() => $"{FigureType.ShownName}:{Owner.Id}";
}
