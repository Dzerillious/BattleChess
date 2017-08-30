using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BattleChess3.Figures;
using BattleChess3.Game;
using BattleChess3.Menu;

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
        }

        /// <summary>
        /// Called when new game is clicked
        /// </summary>
        private void OnNewGameClick(object sender, RoutedEventArgs e)
        {
            if (Session.SelectedMap.Figure != null)
            {
                GameTab.IsEnabled = true;
                Session.LoadMap();
                Session.SetBindedBoard();
                GameTab.IsSelected = true;
            }
        }
        
        private void OnDeleteMapClicked(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnOptionsClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnQuitApplicationClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Called when selected map is changed
        /// </summary>
        private void OnSelectedMapChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox) sender;
            Session.SelectedMap = (Map)listBox.SelectedItem;
        }
        
        /// <summary>
        /// Called when chess tile button is clicked
        /// </summary>
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var figure = (BaseFigure) button.CommandParameter;
            Session.ClickedAtPosition(figure.Position);
        }

        /// <summary>
        /// Called when mouse enters chess tile
        /// </summary>
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            var button = (Button) sender;
            var figure = (BaseFigure) button.CommandParameter;
            Session.MouseOn.SelFigure = figure;
            Session.MouseOn.SelPosition = figure.Position;
        }

        private void OnSaveMapClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        private void OnManualClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
