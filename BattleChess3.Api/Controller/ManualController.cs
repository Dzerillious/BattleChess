using BattleChess3.Model;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace BattleChess3.Api.Controller
{
    public partial class ManualController
    {
        public ManualController()
        {
            InitializeComponent();
        }
       
        private void OnManualSelectedClick(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer("Sounds/BoardSound.wav");
            snd.Play();
            var button = (Button)sender;
            ManualContent.DataContext = TypesOfFigures.FigureGroups.FirstOrDefault(x => x.Name == button.Content);
        }
    }
}