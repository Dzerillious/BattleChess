using System;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.Core.Model
{
    public class MapBlueprint
    {
        public static readonly MapBlueprint None = new MapBlueprint();
        public string Path { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string PreviewPath { get; set; } = string.Empty;
        public int StartingPlayer { get; set; } = 0;
        public int PlayersCount { get; set; } = 2;
        public FigureBlueprint[] Figures { get; set; } = Array.Empty<FigureBlueprint>();
    }
}