using System;

namespace BattleChess3.Core.Model.Figure
{
    /// <summary>
    /// Class for each figure
    /// </summary>
    public class Figure
    {
        public static readonly Figure Empty = new Figure(Player.Neutral, EmptyFigure.Instance);
        
        public Player Owner = Player.Neutral;
        public IFigureType FigureType { get; set; }
        public double Hp { get; set; }

        public Uri ImageUri => FigureType.ImageUris[Owner.Id];

        public Figure(IFigureType figureType)
        {
            FigureType = figureType;
        }

        /// <summary>
        /// Constructor of baseFigure
        /// </summary>
        public Figure(Player owner, IFigureType figureType)
        {
            Hp = 100;
            Owner = owner;
            FigureType = figureType;
        }

        public override string ToString() => $"{FigureType.UnitName}{Owner}";
    }
}