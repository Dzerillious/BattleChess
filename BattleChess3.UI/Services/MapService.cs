using BattleChess3.Core.Figures;
using BattleChess3.UI.ViewModel;

namespace BattleChess3.UI.Services
{
    public class MapService
    {
        private readonly BoardService _boardService = CommonServiceLocator.ServiceLocator.Current.GetInstance<BoardService>();
        private readonly PlayerService _playerService = CommonServiceLocator.ServiceLocator.Current.GetInstance<PlayerService>();
        public static Map SelectedMap = new Map();

        /// <summary>
        /// If map is not loaded creates empty map.
        /// Calls GetMap
        /// </summary>
        public void LoadMap()
        {
            for (var i = 0; i < 64; i++)
                _boardService.Board[i].Figure = Figure.Empty;
            
            _playerService.CurrentPlayer = SelectedMap.StartingPlayer;
            for (var i = 0; i < SelectedMap.Figure.Length; i++)
            {
                var tiles = SelectedMap.Figure[i];
                foreach (var tile in tiles)
                {
                    var playerIndex = int.Parse(tile.Substring(0, 1));
                    var figureName = tile.Substring(1);
                    _boardService.CreateFigure(figureName, i, _playerService.Players[playerIndex]);
                }
            }
        }
    }
}