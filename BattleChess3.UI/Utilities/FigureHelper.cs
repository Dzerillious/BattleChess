using System.IO;
using BattleChess3.Core.Models;

namespace BattleChess3.UI.Utilities
{
    public static class FigureHelper
    {
        public static Figure Empty { get; }
            = new Figure(DefaultFigures.Empty.Instance)
            {
                Hp = 100,
                Owner = Player.Neutral,
            };
    }
}