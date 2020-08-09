using System.IO;
using BattleChess3.Core;
using BattleChess3.DefaultFigures;

namespace BattleChess3.UI.Utilities
{
    public class FigureHelper
    {
        public static Figure Empty { get; }
            = new Figure(Nothing.Instance)
            {
                Hp = 100,
                Owner = Player.Neutral,
                Highlighted = Directory.GetCurrentDirectory() + "Pictures\\Nothing.png",
                PicturePath =  Figure.GetFigurePicturePath(Nothing.Instance, 0)
            };
    }
}