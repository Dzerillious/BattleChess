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
        private List<Map> _maps = new List<Map>();
        public List<Map> Maps
        {
            get => _maps;
            set
            {
                _maps = value;
                OnPropertyChanged();
            }
        }

        public List<Map> GetMaps()
        {
            var maps = new List<Map>();
            var filePaths = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Maps");
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
            return new Map(path, Path.Combine(Directory.GetCurrentDirectory(), lines[8]), lines[9], tiles);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}