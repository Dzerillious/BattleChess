using BattleChess3.GameData.Figures;
using System.Collections.Generic;

namespace BattleChess3.Game
{
    public class Player
    {
        public string Color;
        public List<BaseFigure> Figures = new List<BaseFigure>();

        public Player(string color)
        {
            Color = color;
        }

        public void CreateFigure(BaseFigure figure)
        {
            Figures.Add(figure);
        }

        public void KillFigure(BaseFigure figure)
        {
            for (var i = 0; i < Figures.Count; i++)
            {
                if (figure == Figures[i])
                {
                    Figures.RemoveAt(i);
                }
            }
        }
    }
}