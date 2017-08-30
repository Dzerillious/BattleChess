using System.IO;
using System.Linq;
using BattleChess3.Properties;

namespace BattleChess3.Menu
{
    /// <summary>
    /// Static class for maps holder
    /// </summary>
    public static class Maps
    {
        private static Map[] _map;
        /// <summary>
        /// Array of Maps in dictionary
        /// </summary>
        public static Map[] Map
        {
            get
            {
                if (_map == null)
                {
                    GetMaps();
                }
                return _map;
            }
            set => _map = value;
        }

        /// <summary>
        /// Gets all maps from dictionary
        /// </summary>
        public static void GetMaps()
        {
            var filePaths = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Maps");
            Map = new Map[filePaths.Count()];
            for (var index = 0; index < filePaths.Length; index++)
            {
                var tiles = new string[8][];
                for (var i = 0; i < 8; i++)
                {
                    tiles[i] = new string[8];
                }
                var filePath = filePaths[index];
                var lines = File.ReadAllLines(filePath);
                for (var i = 0; i < 8; i++)
                {
                    var tile = lines[7 - i].Split(' ');
                    for (var j = 0; j < 8; j++)
                    {
                        tiles[i][j] = tile[j];
                    }
                }
                Map[index] = new Map(filePath, lines[8], tiles);
            }
        }
    }
}