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
        }
    }
}