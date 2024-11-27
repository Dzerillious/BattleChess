using BattleChess3.Game.Players;

namespace BattleChess3.Game.Figures;

internal class FigureCreator : IFigureCreator
{
    private readonly IPlayerService _playerService;
    private readonly IFigureService _figureService;

    public FigureCreator(
        IPlayerService playerService,
        IFigureService figureService)
    {
        _playerService = playerService;
        _figureService = figureService;
    }

    public Figure CreateFigure(FigureIdentifier figureIdentifier)
    {
        var figureType = _figureService.GetFigureFromName(figureIdentifier.UnitName);
        var player = _playerService.GetPlayer(figureIdentifier.PlayerId);
        var figure = new Figure(figureIdentifier.FigureId, player, figureType);
        player.Figures.Add(figure);
        return figure;
    }

    public Figure CreateEmptyFigure()
    {
        var figureIdentifier = new FigureIdentifier(0, IEmptyFigureType.EmptyUnitName);
        var figureType = _figureService.GetFigureFromName(figureIdentifier.UnitName);
        return new Figure(Player.Neutral, figureType);
    }
}