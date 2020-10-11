using Autofac;
using Autofac.Extras.CommonServiceLocator;
using BattleChess3.UI.Services;
using BattleChess3.UI.ViewModel;
using CommonServiceLocator;

namespace BattleChess3.UI
{
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
                   .AsSelf()
                   .SingleInstance();
            builder.RegisterType<MapService>()
                   .AsSelf()
                   .SingleInstance();
            builder.RegisterType<FigureService>()
                   .AsSelf()
                   .SingleInstance();
            builder.RegisterType<PlayerService>()
                   .AsSelf()
                   .SingleInstance();
            
            builder.RegisterType<MainWindowViewModel>()
                   .AsSelf();
            

            var locator = new AutofacServiceLocator(builder.Build());
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}