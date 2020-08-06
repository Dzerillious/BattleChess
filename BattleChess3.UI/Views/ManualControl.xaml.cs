using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BattleChess3.Core;

namespace BattleChess3.UI.Views
{
    public partial class ManualControl
    {
        public ManualControl()
        {
            InitializeComponent();
        }
       
        private void OnManualSelectedClick(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer("Resources/Sounds/BoardSound.wav");
            snd.Play();
            var button = (Button)sender;
            ManualContent.DataContext = TypesOfFigures.FigureGroups.FirstOrDefault(x => x.Name == button.Content);
        }
    }
}