namespace BattleChess3.UI.ViewModel
{
    /// <summary>
    /// Class for each map
    /// </summary>
    public class Map
    {
        public string Name { get; set; }
        public int StartingPlayer { get; set; }
        public string[][] Figure { get; set; }
        public string PreviewPath { get; set; }

        public Map()
        {
            Name = null;
            StartingPlayer = 1;
            Figure = null;
            PreviewPath = null;
        }

        public Map(string name, string previewPath, int startingPlayer, string[][] figure)
        {
            Name = name;
            StartingPlayer = startingPlayer;
            Figure = figure;
            PreviewPath = previewPath;
        }
    }
}