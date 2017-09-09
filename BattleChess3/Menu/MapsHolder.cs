using System.IO;
using System.Linq;

namespace BattleChess3.Menu
{
    /// <summary>
    /// Class for maps holder
    /// </summary>
    public static class Maps
    {
        private static readonly Map[] _mapsHolder = new Map[100];
        /// <summary>
        /// Array of Maps in dictionary
        /// </summary>
        public static Map[] MapsHolder
        {
            get
            {
                for (var i = 0; i < 100; i++)
                {
                    if (_mapsHolder[i] == null)
                    {
                        _mapsHolder[i] = new Map();
                    }
                }
                var filePaths = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Maps");
                for (var i = 0; i < filePaths.Length && i < 100; i++)
                {
                    _mapsHolder[i] = GetMapFromPath(filePaths[i]);
                }
                return _mapsHolder;
            }
        }

        private static Map GetMapFromPath(string path)
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
            return new Map(path, lines[8], lines[9], tiles);
        }
        
        public static Map FindFirstEmptyMap() => MapsHolder.FirstOrDefault(map => map.Name == null);
    }
}