using Autofac;
using Autofac.Extras.CommonServiceLocator;
using BattleChess3.Game;
using BattleChess3.Maps;
using BattleChess3.Multiplayer;
using BattleChess3.UI.Themes;
using BattleChess3.UI.ViewModel;
using CommonServiceLocator;

namespace BattleChess3.UI;

public static class DependenciesBuilder
{
    public static void Initialize()
    {
        if (ServiceLocator.IsLocationProviderSet) 
            return;
        
        var builder = new ContainerBuilder();
        SetUpComponents(builder);
        SetUpServiceLocator(builder);
            
        var locator = new AutofacServiceLocator(builder.Build());
        ServiceLocator.SetLocatorProvider(() => locator);
    }

    private static void SetUpComponents(ContainerBuilder builder)
    {
        builder.RegisterGamesModule();
        builder.RegisterMapsComponent();
        builder.RegisterMultiplayerModule();
    }

    private static void SetUpServiceLocator(ContainerBuilder builder)
    {
        builder.RegisterType<ThemeService>()
            .As<IThemeService>()
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
    }
}