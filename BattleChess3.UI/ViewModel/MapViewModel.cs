using BattleChess3.Core;

namespace BattleChess3.UI.ViewModel
{
    /// <summary>
    /// Class for each map
    /// </summary>
    public class Map
    {
        public string Name { get; set; }
        public Player StartingPlayer { get; set; }
        public string[][] Figure { get; set; }
        public string PreviewPath { get; set; }

        public Map()
        {
            Name = "";
            StartingPlayer = new Player(1);
            Figure = new string[0][];
            PreviewPath = "";
        }

        public Map(string name, string previewPath, int startingId, string[][] figure)
        {
            Name = name;
            StartingPlayer = new Player(startingId);
            Figure = figure;
            PreviewPath = previewPath;
        }
    }
}