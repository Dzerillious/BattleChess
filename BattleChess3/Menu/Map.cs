namespace BattleChess3.Menu
{
    public class Map
    {
        public string Name { get; set; }
        public string PreviewPath { get; set; }
        public string[][] Figure { get; set; }

        public Map(string name, string previewPath, string[][] figure)
        {
            Name = name;
            PreviewPath = previewPath;
            Figure = figure;
        }
    }
}