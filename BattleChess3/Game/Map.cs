using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BattleChess3.Annotations;

namespace BattleChess3.Game
{
    /// <summary>
    /// Class for each map
    /// </summary>
    public class Map : INotifyPropertyChanged, IDisposable
    {
        private string _previewPath;

        public string Name { get; set; }

        public string StartingPlayer { get; set; }

        public string[][] Figure { get; set; }

        public string PreviewPath{
            get => _previewPath;
            set
            {
                _previewPath = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Creates empty map
        /// </summary>
        public Map()
        {
            Name = null;
            StartingPlayer = null;
            Figure = null;
            PreviewPath = null;
        }

        /// <summary>
        /// Creates new map from params
        /// </summary>
        public Map(string name, string previewPath, string startingPlayer, string[][] figure)
        {
            Name = name;
            StartingPlayer = startingPlayer;
            Figure = figure;
            PreviewPath = previewPath;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// On PreviewPath changed
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <inheritdoc />
        /// <summary>
        /// Empties Map
        /// </summary>
        public void Dispose()
        {
            PreviewPath = null;
            Name = null;
            StartingPlayer = null;
            Figure = null;
        }
    }
}