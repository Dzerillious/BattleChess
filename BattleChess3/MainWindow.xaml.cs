using System.Windows;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game.Play.LoadMap("C:\\Users\\sery\\Documents\\Visual Studio 2017\\Projects\\1\\battle-chess-3.0\\BattleChess3\\Maps\\ClassicMap.txt");
            PlayTurn(1, 1);
            PlayTurn(1, 2);
        }

        private void PlayTurn(int i, int j)
        {
            Game.Play.ClickedAtPosition(new Position(i, j));
        }
    }
}
