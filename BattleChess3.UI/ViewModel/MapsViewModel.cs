using BattleChess3.Core.Model;
using BattleChess3.UI.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleChess3.UI.ViewModel;

public class MapsViewModel : ViewModelBase
{
    private IMapService _mapService;

    private MapBlueprint _selectedMap = MapBlueprint.None;
    public MapBlueprint SelectedMap
    {
        get => _selectedMap;
        set => Set(ref _selectedMap, value);
    }

    private IList<MapBlueprint> _maps = Array.Empty<MapBlueprint>();
    public IList<MapBlueprint> Maps
    {
        get => _maps;
        set
        {
            Set(ref _maps, value);
            if (!_maps.Contains(_selectedMap))
            {
                _selectedMap = _maps.FirstOrDefault() 
                    ?? MapBlueprint.None;
            }
        }
    }

    public MapsViewModel(IMapService mapService)
    {
        _mapService = mapService;
        Maps = _mapService.GetCurrentMaps();
        _mapService.MapsChanged += OnMapsChanged;
    }

    public void OnMapsChanged(object sender, IList<MapBlueprint> maps)
    {
        Maps = maps;
    }
}
