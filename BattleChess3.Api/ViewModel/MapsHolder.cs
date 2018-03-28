using BattleChess3.Api.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BattleChess3.Api.ViewModel
{
    public class MapsHolder : INotifyPropertyChanged
    {
        private readonly List<Map> maps = new List<Map>();

        public List<Map> Maps
        {
            get
            {
                var filePaths = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Maps");
                foreach (var path in filePaths)
                {
                    maps.Add(GetMapFromPath(path));
                }
                return maps;
            }
        }

        public void AddMap(Map map)
        {
            Maps.Add(map);
            OnPropertyChanged();
        }

        public void RemoveMap(Map map)
        {
            Maps.RemoveAll(x => x == map);
            OnPropertyChanged();
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
            return new Map(path, Path.Combine(Directory.GetCurrentDirectory(), lines[8]), lines[9], tiles);
        }

        public Map FindFirstEmptyMap() => Maps.FirstOrDefault(map => map.Name == null);

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}