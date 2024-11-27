using Autofac;

namespace BattleChess3.Maps;

public static class MapsModule
{
    public static void RegisterMapsComponent(this ContainerBuilder builder)
    {
        builder.RegisterType<MapService>()
            .As<IMapService>()
            .SingleInstance();
        builder.RegisterType<MapLoader>()
            .As<IMapLoader>()
            .SingleInstance();
    }
}