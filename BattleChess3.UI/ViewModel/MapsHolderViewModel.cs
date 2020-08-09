using System.Collections.Generic;
using System.IO;
using BattleChess3.Core.Models;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel
{
    public class MapsHolder : ViewModelBase
    {
        private List<MapBlueprint> _maps = new List<MapBlueprint>();
        public List<MapBlueprint> Maps
        {
            get => _maps;
            set => Set(ref _maps, value);
        }

        public List<MapBlueprint> GetMaps()
        {
            var maps = new List<MapBlueprint>();
            var filePaths = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Resources\\Maps");
            foreach (var path in filePaths)
            {
                maps.Add(GetMapFromPath(path));
            }
            return maps;
        }

        private MapBlueprint GetMapFromPath(string path)
        {
            // var tiles = new string[8][];
            // for (var i = 0; i < 8; i++)
            // {
            //     tiles[i] = new string[8];
            // }
            // var lines = File.ReadAllLines(path);
            // for (var i = 0; i < 8; i++)
            // {
            //     var tile = lines[7 - i].Split(' ');
            //     for (var j = 0; j < 8; j++)
            //     {
            //         tiles[i][j] = tile[j];
            //     }
            // }
            // return new Map(path, Path.Combine(Directory.GetCurrentDirectory(), lines[8]), int.Parse(lines[9]), tiles);
            return new MapBlueprint();
        }
    }
}