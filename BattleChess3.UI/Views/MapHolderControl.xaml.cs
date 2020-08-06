using System.Windows.Controls;
using BattleChess3.UI.Game;
using BattleChess3.UI.ViewModel;

namespace BattleChess3.UI.Views
{
    public partial class MapHolderController
    {
        public MapHolderController()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when selected map is changed
        /// </summary>
        private void OnSelectedMapChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            Session.SelectedMap = (Map)listBox.SelectedItem;
        }
    }
}