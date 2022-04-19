using System;

namespace BattleChess3.Core.Model.Figures;

public class Figure
{
    public static readonly Figure None = new Figure(Player.Neutral, NoneFigure.Instance, 0);
    
    public Player Owner { get; }
    public IFigureType FigureType { get; set; }
    public double Hp { get; set; }
    public Uri ImageUri => FigureType.ImageUris[Owner.Id];

    public Figure(Player owner, IFigureType figureType, double hp)
    {
        Hp = hp;
        Owner = owner;
        FigureType = figureType;
    }

    public bool CanAttack(Figure figure)
    {
        if (Owner.Id == figure.Owner.Id) return false;
        return figure.Hp - FigureType.AttackCalculation(figure.FigureType) <= 0;
    }

    public override string ToString() => $"{FigureType.ShownName}:{Owner.Id}";
}
