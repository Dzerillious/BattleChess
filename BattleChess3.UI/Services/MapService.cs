using System.IO;
using System.Linq;
using BattleChess3.Core.Models;
using BattleChess3.Core.Utilities;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace BattleChess3.UI.Services
{
    public class MapService : ViewModelBase
    {
        // private readonly BoardService _boardService = CommonServiceLocator.ServiceLocator.Current.GetInstance<BoardService>();
        // private readonly PlayerService _playerService = CommonServiceLocator.ServiceLocator.Current.GetInstance<PlayerService>();
        
        public MapBlueprint[] Maps { get; set; } 
        public MapBlueprint SelectedMap { get; set; }

        /// <summary>
        /// If map is not loaded creates empty map.
        /// Calls GetMap
        /// </summary>
        // public void LoadMap()
        // {
        //     // for (var i = 0; i < 64; i++)
        //     //     _boardService.Board[i].Figure = FigureHelper.Empty;
        //     //
        //     // _playerService.CurrentPlayer = SelectedMap.StartingPlayer;
        //     // for (var i = 0; i < SelectedMap.Blueprint.Length; i++)
        //     // {
        //     //     var tiles = SelectedMap.Blueprint[i];
        //     //     foreach (var tile in tiles)
        //     //     {
        //     //         var playerIndex = int.Parse(tile.Substring(0, 1));
        //     //         var figureName = tile.Substring(1);
        //     //         _boardService.CreateFigure(figureName, i, _playerService.Players[playerIndex]);
        //     //     }
        //     // }
        // }

        public MapService()
        {
            LoadMaps();
        }

        private void LoadMaps()
        {
            DirectoryInfo directory = new DirectoryInfo("Resources/Maps");
            Maps = directory.GetFiles("*.map")
                .Select(file =>
                {
                    string text = File.ReadAllText(file.FullName);
                    text = CompressionHelper.Decompress(text);
                    return JsonConvert.DeserializeObject<MapBlueprint>(text);
                })
                .ToArray();
            SelectedMap = Maps.First();
        }
    }
}