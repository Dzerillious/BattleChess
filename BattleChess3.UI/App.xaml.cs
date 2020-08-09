using BattleChess3.Core.Services;
using BattleChess3.UI.Services;
using BattleChess3.UI.Utilities;

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
        }
    }
}