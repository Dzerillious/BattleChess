using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using BattleChess3.Core.Services;

namespace BattleChess3.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            DependenciesBuilder.Initialize();
            CommonServiceLocator.ServiceLocator.Current.GetInstance<FigureService>();
            // CommonServiceLocator.ServiceLocator.Current.GetInstance<MapService>();
            // Current.Resources["ApplicationBackground"] = new BitmapImage(new Uri("Resources/Styles/PaperStyle/ApplicationBackground.jpg", UriKind.RelativeOrAbsolute));
        }
    }
}