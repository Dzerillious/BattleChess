using Autofac;
using Autofac.Extras.CommonServiceLocator;
using BattleChess3.UI.Services;
using BattleChess3.UI.ViewModel;
using CommonServiceLocator;

namespace BattleChess3.UI;

public class DependenciesBuilder
{
    public static void Initialize()
    {
        if (!ServiceLocator.IsLocationProviderSet)
            SetUpServiceLocator();
    }
    
    public static void Cleanup()
    {
        // clean up resources
    }

    private static void SetUpServiceLocator()
    {
        var builder = new ContainerBuilder();
        
        builder.RegisterType<ThemeService>()
               .As<IThemeService>()
               .SingleInstance();
        builder.RegisterType<MapService>()
               .As<IMapService>()
               .SingleInstance();
        builder.RegisterType<FigureService>()
               .As<IFigureService>()
               .SingleInstance();
        builder.RegisterType<PlayerService>()
               .As<IPlayerService>()
               .SingleInstance();
        builder.RegisterType<MultiplayerService>()
               .As<IMultiplayerService>()
               .SingleInstance();

        builder.RegisterType<MapsViewModel>()
               .SingleInstance();
        builder.RegisterType<BoardViewModel>()
               .SingleInstance();
        builder.RegisterType<ThemesViewModel>()
               .SingleInstance();
        builder.RegisterType<FiguresViewModel>()
               .SingleInstance();
        builder.RegisterType<MultiplayerViewModel>()
               .SingleInstance();
        builder.RegisterType<MainWindowViewModel>()
               .SingleInstance();
        

        var locator = new AutofacServiceLocator(builder.Build());
        ServiceLocator.SetLocatorProvider(() => locator);
    }
}
