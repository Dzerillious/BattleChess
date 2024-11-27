using Autofac;
using BattleChess3.Game.Figures;
using BattleChess3.Game.History;
using BattleChess3.Game.Players;

namespace BattleChess3.Game;

public static class GameModule
{
    public static void RegisterGamesModule(this ContainerBuilder builder)
    {
        builder.RegisterType<PlayerService>()
            .As<IPlayerService>()
            .SingleInstance();
        builder.RegisterType<FigureService>()
            .As<IFigureService>()
            .SingleInstance();
        builder.RegisterType<FigureCreator>()
            .As<IFigureCreator>()
            .SingleInstance();
        builder.RegisterType<HistoryService>()
            .As<IHistoryService>()
            .SingleInstance();
    }
}