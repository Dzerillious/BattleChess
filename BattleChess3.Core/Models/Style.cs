using System;
using System.IO;

namespace BattleChess3.Core.Models
{
    /// <summary>
    /// Interface for style of application
    /// </summary>
    public class Style
    {
        public Style(string directory)
        {
            Directory = directory;
            Preview = directory + "\\Preview.png";
        }

        /// <summary>
        /// Gets name of style
        /// </summary>
        public string Directory { get; }

        /// <summary>
        /// Gets path of preview image of style
        /// </summary>
        public string Preview { get; }
    }
}