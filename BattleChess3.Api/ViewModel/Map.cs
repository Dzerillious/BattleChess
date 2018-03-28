using System;

namespace BattleChess3.Api.ViewModel
{
    /// <summary>
    /// Class for each map
    /// </summary>
    public class Map : IDisposable
    {
        public string Name { get; set; }
        public string StartingPlayer { get; set; }
        public string[][] Figure { get; set; }
        public string PreviewPath { get; set; }

        public Map()
        {
            Name = null;
            StartingPlayer = null;
            Figure = null;
            PreviewPath = null;
        }

        public Map(string name, string previewPath, string startingPlayer, string[][] figure)
        {
            Name = name;
            StartingPlayer = startingPlayer;
            Figure = figure;
            PreviewPath = previewPath;
        }

        public void Dispose()
        {
            PreviewPath = null;
            Name = null;
            StartingPlayer = null;
            Figure = null;
        }
    }
}