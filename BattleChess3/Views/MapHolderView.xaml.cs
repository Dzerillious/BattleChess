using System.Windows.Controls;
using BattleChess3.Game;

namespace BattleChess3.Views
{
    public partial class MapHolderView : UserControl
    {
        public MapHolderView()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Called when selected map is changed
        /// </summary>
        private void OnSelectedMapChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox) sender;
            Session.SelectedMap = (Map)listBox.SelectedItem;
        }
    }
}
