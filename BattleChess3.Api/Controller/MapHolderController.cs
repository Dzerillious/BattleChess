using BattleChess3.Api.Game;
using BattleChess3.Api.ViewModel;
using System.Windows.Controls;

namespace BattleChess3.Api.Controller
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