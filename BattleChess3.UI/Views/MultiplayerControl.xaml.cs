using BattleChess3.UI.ViewModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BattleChess3.UI.Views
{
    /// <summary>
    /// Interaction logic for MultiplayerControl.xaml
    /// </summary>
    public partial class MultiplayerControl : UserControl
    {
        public MultiplayerControl()
        {
            InitializeComponent();
        }

        private void Button_Drop(object sender, DragEventArgs e)
        { 
            if (!(e.Data.GetData("text") is MemoryStream ms))
                return;

            var text = Encoding.ASCII.GetString(ms.ToArray());
            var viewModel = DataContext as MultiplayerViewModel;

            if (viewModel is null)
                return;

            viewModel.SetKey(text);
        }

        private void Button_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }
    }
}
