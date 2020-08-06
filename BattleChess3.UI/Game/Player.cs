using System.Collections.Generic;
using BattleChess3.Core.Figures;

namespace BattleChess3.UI.Game
{
    public class Player
    {
        public int Number;
        public List<BaseFigure> Figures = new List<BaseFigure>();

        public Player(int number)
        {
            Number = number;
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