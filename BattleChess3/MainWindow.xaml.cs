using System.Windows;
using System.Windows.Controls;
using BattleChess3.Figures;
using BattleChess3.Game;

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
            Play.LoadMap("C:\\Users\\danys\\OneDrive\\Documents\\battle-chess-3.0\\BattleChess3\\Maps\\ClassicMap.txt");
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
