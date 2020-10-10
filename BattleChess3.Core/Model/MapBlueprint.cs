using BattleChess3.Core.Model.Figure;

namespace BattleChess3.Core.Model
{
    /// <summary>
    /// Class for each map
    /// </summary>
    public class MapBlueprint
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string PreviewPath { get; set; }
        public int StartingPlayer { get; set; }
        public int PlayersCount { get; set; }
        public FigureBlueprint[] Blueprint { get; set; }
    }
}