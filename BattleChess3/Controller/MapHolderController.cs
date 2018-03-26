using BattleChess3.Game;
using System.Windows.Controls;

namespace BattleChess3.Controller
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