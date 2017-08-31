using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using BattleChess3.Annotations;

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
                    var filePaths = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Maps");
                    _map = new Map[filePaths.Count()];
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
                        _map[index] = new Map(filePath, lines[8], lines[9], tiles);
                    }
                }
                return _map;
            }
        }
    }
}