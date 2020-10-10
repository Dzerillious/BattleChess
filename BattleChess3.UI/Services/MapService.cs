using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.Core.Resources;
using BattleChess3.Core.Utilities;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace BattleChess3.UI.Services
{
    public class MapService : ViewModelBase
    {
        private readonly FigureService _figureService = ServiceLocator.Current.GetInstance<FigureService>();
        private readonly PlayerService _playerService = ServiceLocator.Current.GetInstance<PlayerService>();
        private readonly BoardService _boardService = ServiceLocator.Current.GetInstance<BoardService>();
        
        private MapBlueprint[] _maps = Array.Empty<MapBlueprint>();
        public MapBlueprint[] Maps
        {
            get => _maps;
            set => Set(ref _maps, value);
        }

        private MapBlueprint _selectedMap = MapBlueprint.Empty;
        public MapBlueprint SelectedMap
        {
            get => _selectedMap;
            set => Set(ref _selectedMap, value);
        }

        public MapService()
        {
            Task.Run(ReloadMaps);
        }

        public void ReloadMaps()
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

        public void LoadMap(MapBlueprint map)
        {
            _playerService.InitializePlayers(map.PlayersCount, map.StartingPlayer);
            for (var i = 0; i < Constants.BoardSize; i++)
            {
                var figureBlueprint = map.Figures[i];
                _boardService.Board[i].Figure = CreateFigure(figureBlueprint);
            }
        }

        private Figure CreateFigure(FigureBlueprint figureBlueprint)
        {
            var figureType = _figureService.GetFigureFromName(figureBlueprint.FigureName);
            var player = _playerService.GetPlayer(figureBlueprint.PlayerId);
            var figure = new Figure(player, figureType);
            player.Figures.Add(figure);
            return figure;
        }
    }
}