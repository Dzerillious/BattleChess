using System.Windows;
using System.Windows.Controls;
using BattleChess3.Figures;

namespace BattleChess3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Game.Play.LoadMap("C:\\Users\\sery\\Documents\\Visual Studio 2017\\Projects\\1\\battle-chess-3.0\\BattleChess3\\Maps\\ClassicMap.txt");
            Game.Play.SetBoard1D();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var figure = (BaseFigure) button.CommandParameter;
            Game.Play.ClickedAtPosition(figure.Position);
        }
    }
}
