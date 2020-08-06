using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BattleChess3.Core.Figures;
using BattleChess3.UI.Game;

namespace BattleChess3.UI.Views
{
    public partial class GameBoardView
    {
        public GameBoardView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when chess tile button is clicked
        /// </summary>
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer("Sounds/BoardSound.wav");
            snd.Play();
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
            Session.MouseOn.Figure = figure;
            Session.MouseOn.Position = figure.Position;
        }
    }
}