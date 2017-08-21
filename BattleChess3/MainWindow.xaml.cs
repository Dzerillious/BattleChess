using System.Windows;
using System.Windows.Controls;
using BattleChess3.Figures;
using BattleChess3.Game;
using BattleChess3.Properties;

namespace BattleChess3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Play.LoadMap("C:\\Users\\sery\\Documents\\Visual Studio 2017\\Projects\\1\\battle-chess-3.0\\BattleChess3\\Maps\\ClassicMap.txt");
            Play.SetBindedBoard();
        }

        /// <summary>
        /// Called when button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var figure = (BaseFigure) button.CommandParameter;
            Play.ClickedAtPosition(figure.Position);
        }
    }
}
