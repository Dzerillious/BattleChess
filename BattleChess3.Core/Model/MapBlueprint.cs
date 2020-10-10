using System;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.Core.Model
{
    /// <summary>
    /// Class for each map
    /// </summary>
    public class MapBlueprint
    {
        public string Path { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string PreviewPath { get; set; } = string.Empty;
        public int StartingPlayer { get; set; } = 0;
        public int PlayersCount { get; set; } = 2;
        public FigureBlueprint[] Blueprint { get; set; } = Array.Empty<FigureBlueprint>();
    }
}