using System.ComponentModel;
using System.Runtime.CompilerServices;
using BattleChess3.Annotations;

namespace BattleChess3.Game.Styles
{
    public class SelectedStyle : INotifyPropertyChanged
    {
        private IStyle _applicationStyle;
        /// <summary>
        /// Property for Application Style
        /// </summary>
        public IStyle ApplicationStyle
        {
            get => _applicationStyle ?? (_applicationStyle = new PaperStyle());
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