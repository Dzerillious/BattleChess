using System.Collections.Generic;
using System.IO;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel
{
    public class MapsHolder : ViewModelBase
    {
        private List<Map> _maps = new List<Map>();
        public List<Map> Maps
        {
            get => _maps;
            set => Set(ref _maps, value);
        }

        public List<Map> GetMaps()
        {
            var maps = new List<Map>();
            var filePaths = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Resources\\Maps");
            foreach (var path in filePaths)
            {
                maps.Add(GetMapFromPath(path));
            }
            return maps;
        }

        private Map GetMapFromPath(string path)
        {
            var tiles = new string[8][];
            for (var i = 0; i < 8; i++)
            {
                tiles[i] = new string[8];
            }
            var lines = File.ReadAllLines(path);
            for (var i = 0; i < 8; i++)
            {
                var tile = lines[7 - i].Split(' ');
                for (var j = 0; j < 8; j++)
                {
                    tiles[i][j] = tile[j];
                }
            }
            return new Map(path, Path.Combine(Directory.GetCurrentDirectory(), lines[8]), int.Parse(lines[9]), tiles);
        }
    }
}