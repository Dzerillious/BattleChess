using BattleChess3.Game;
using BattleChess3.GameData.Figures;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BattleChess3.Controller
{
    public partial class GameBoardController
    {
        public GameBoardController()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when chess tile button is clicked
        /// </summary>
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var figure = (BaseFigure)button.CommandParameter;
            Session.ClickedAtPosition(figure.Position);
        }

        /// <summary>
        /// Called when mouse enters chess tile
        /// </summary>
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            var figure = (BaseFigure)button.CommandParameter;
            Session.MouseOn.SelFigure = figure;
            Session.MouseOn.SelPosition = figure.Position;
        }
    }
}