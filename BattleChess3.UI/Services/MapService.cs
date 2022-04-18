using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BattleChess3.Core.Model;
using BattleChess3.Core.Utilities;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace BattleChess3.UI.Services;

public class MapService : ViewModelBase
{
    private MapBlueprint _selectedMap = MapBlueprint.None;
    public MapBlueprint SelectedMap
    {
        get => _selectedMap;
        set => Set(ref _selectedMap, value);
    }
    
    private MapBlueprint[] _maps = Array.Empty<MapBlueprint>();
    public MapBlueprint[] Maps
    {
        get => _maps;
        set => Set(ref _maps, value);
    }

    public MapService()
    {
        Task.Run(ReloadMaps);
    }

    public void ReloadMaps()
    {
        Maps = Directory.GetFiles("Resources/Maps", "*.map")
                        .Select(path =>
                         {
                             string text = File.ReadAllText(Path.GetFullPath(path));
                             text = CompressionHelper.Decompress(text);
                             return JsonConvert.DeserializeObject<MapBlueprint>(text);
                         })
                        .ToArray();
        SelectedMap = Maps.First();
    }
}
