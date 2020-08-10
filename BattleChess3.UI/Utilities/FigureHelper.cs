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
                Highlighted = Directory.GetCurrentDirectory() + "Pictures\\Nothing.png",
                PicturePath =  Figure.GetFigurePicturePath(DefaultFigures.Empty.Instance, 0)
            };
    }
}