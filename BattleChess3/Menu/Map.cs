namespace BattleChess3.Menu
{
    /// <summary>
    /// Class for each map
    /// </summary>
    public class Map
    {
        public string Name { get; set; }
        public string PreviewPath { get; set; }
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
        /// <param name="figure"></param>
        public Map(string name, string previewPath, string[][] figure)
        {
            Name = name;
            PreviewPath = previewPath;
            Figure = figure;
        }
    }
}