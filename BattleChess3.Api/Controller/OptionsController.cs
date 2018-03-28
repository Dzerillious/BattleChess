using BattleChess3.Api.Game;
using BattleChess3.Model;
using System.Windows.Controls;

namespace BattleChess3.Api.Controller
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