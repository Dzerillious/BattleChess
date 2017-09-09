using System.Collections.Generic;
using BattleChess3.Figures;

namespace BattleChess3.Game
{
    /// <summary>
    /// Class for player
    /// </summary>
    public class Player
    {
        public string Color;
        public List<BaseFigure> Figures = new List<BaseFigure>();

        public Player(string color)
        {
            Color = color;
        }

        /// <summary>
        /// Creates figure at certain position
        /// </summary>
        /// <param name="figure">Created figure</param>
        public void CreateFigure(BaseFigure figure)
        {
            Figures.Add(figure);
        }

        /// <summary>
        /// Removes figure at certain position
        /// </summary>
        /// <param name="figure">Killed figure</param>
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
