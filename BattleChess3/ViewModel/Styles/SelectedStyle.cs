using BattleChess3.Annotations;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace BattleChess3.ViewModel.Styles
{
    public class SelectedStyle : INotifyPropertyChanged
    {
        private Style _applicationStyle;

        /// <summary>
        /// Property for Application Style
        /// </summary>
        public Style ApplicationStyle
        {
            get => _applicationStyle ?? (_applicationStyle = new Style(Directory.GetCurrentDirectory() + "\\Pictures\\Styles\\PaperStyle"));
            set
            {
                _applicationStyle = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// On SelectedStyle changed
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}