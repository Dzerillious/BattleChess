using System.Windows.Controls;
using BattleChess3.Core;
using BattleChess3.UI.Game;

namespace BattleChess3.UI.Views
{
    public partial class OptionsControl
    {
        public OptionsControl()
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