namespace BattleChess3.Menu
{
    /// <summary>
    /// Class for each map
    /// </summary>
    public class Map
    {
        public string Name { get; set; }
        public string PreviewPath { get; set; }
        public string StartingPlayer { get; set; }
        public string[][] Figure { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Map()
        {
        }

        /// <summary>
        /// Create map
        /// </summary>
        /// <param name="name"></param>
        /// <param name="previewPath"></param>
        /// <param name="startingPlayer"></param>
        /// <param name="figure"></param>
        public Map(string name, string previewPath, string startingPlayer, string[][] figure)
        {
            Name = name;
            PreviewPath = previewPath;
            StartingPlayer = startingPlayer;
            Figure = figure;
        }
    }
}