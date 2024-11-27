using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;
using BattleChess3.Game.Players;

namespace BattleChess3.Maps;

internal class MapLoader : IMapLoader
{
    private readonly IFigureCreator _figureCreator;
    private readonly IPlayerService _playerService;

    public MapLoader(
        IPlayerService playerService,
        IFigureCreator figureCreator)
    {
        _playerService = playerService;
        _figureCreator = figureCreator;
    }
    
    public void LoadMap(IBoard board, MapBlueprint map)
    {
        _playerService.InitializePlayers(map.StartingPlayer);

        for (var i = 0; i < IBoard.TilesCount; i++)
        {
            board[i].Figure = _figureCreator.CreateFigure(map.Figures[i]);
        }
    }
}