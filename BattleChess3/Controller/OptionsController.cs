using BattleChess3.Game;
using BattleChess3.GameData.Styles;
using System.Windows.Controls;

namespace BattleChess3.Controller
{
    public partial class OptionsController
    {
        public OptionsController()
        {
            InitializeComponent();
        }

        private void OnSelectedStyleChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            Session.SelectedStyle.ApplicationStyle = (Style)listBox.SelectedItem;
            InitializeComponent();
        }
    }
}