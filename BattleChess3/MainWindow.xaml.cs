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
            Game.Play.LoadMap("C:\\Users\\sery\\Documents\\Visual Studio 2017\\Projects\\ChessBattle3\\BattleChess3\\BattleChess3\\Maps\\ClassicMap.txt");
        }
    }
}
