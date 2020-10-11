using System;

namespace BattleChess3.Core.Model.Figures
{
    public class Figure
    {
        public static readonly Figure None = new Figure(Player.Neutral, NoneFigure.Instance);
        
        public Player Owner { get; }
        public IFigureType FigureType { get; set; }
        public double Hp { get; set; }
        public Uri ImageUri => FigureType.ImageUris[Owner.Id];

        public Figure(Player owner, IFigureType figureType)
        {
            Hp = 100;
            Owner = owner;
            FigureType = figureType;
        }

        public bool CanKill(Figure figure)
        {
            if (Owner.Id == figure.Owner.Id) return false;
            double bonusCoefficient = (figure.FigureType.UnitTypes & FigureType.Bonus) > 0 ? 2 : 1;
            double antiBonusCoefficient = (figure.FigureType.UnitTypes & FigureType.Bonus) > 0 ? 0.5 : 1;
            return figure.Hp - (FigureType.Attack - figure.FigureType.Defence) * bonusCoefficient * antiBonusCoefficient <= 0;
        }

        public override string ToString() => $"{FigureType.UnitName}{Owner}";
    }
}