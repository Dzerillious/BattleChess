using BattleChess3.UI.Utilities;
using GalaSoft.MvvmLight.Threading;

namespace BattleChess3.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    public App()
    {
        DispatcherHelper.Initialize();
        DependenciesBuilder.Initialize();
    }
}
