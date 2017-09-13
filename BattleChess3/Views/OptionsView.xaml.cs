using System.Windows.Controls;
using BattleChess3.Game;
using BattleChess3.GameData.Styles;

namespace BattleChess3.Views
{
    public partial class OptionsView : UserControl
    {
        public OptionsView()
        {
            InitializeComponent();
        }

        private void OnSelectedStyleChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox) sender;
            Session.SelectedStyle.ApplicationStyle = (Style) listBox.SelectedItem;
            InitializeComponent();
        }
    }
}
