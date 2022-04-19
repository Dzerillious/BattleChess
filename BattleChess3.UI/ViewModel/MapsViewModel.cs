using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.UI.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BattleChess3.UI.ViewModel;

public class MapsViewModel : ViewModelBase, IDisposable
{
    private readonly IMapService _mapService;
    private readonly IPlayerService _playerService;

    private MapBlueprint _selectedMap = MapBlueprint.None;
    public MapBlueprint SelectedMap
    {
        get => _selectedMap;
        set
        {
            if (value == null)
                value = MapBlueprint.None;

            Set(ref _selectedMap, value);
        }
    }

    private ObservableCollection<MapBlueprint> _maps = new ObservableCollection<MapBlueprint>();
    public ObservableCollection<MapBlueprint> Maps
    {
        get => _maps;
        set
        {
            if (!value.Any(x => x.MapPath == _selectedMap.MapPath))
            {
                SelectedMap = value.FirstOrDefault()
                    ?? MapBlueprint.None;
            }
            Set(ref _maps, value);
        }
    }

    public MapsViewModel(
        IMapService mapService,
        IPlayerService playerService)
    {
        _mapService = mapService;
        _playerService = playerService;

        Maps = new ObservableCollection<MapBlueprint>(_mapService.GetCurrentMaps());
        _mapService.MapsChanged += OnMapsChanged;
    }

    public void OnMapsChanged(object? sender, IList<MapBlueprint> maps)
    {
        Maps = new ObservableCollection<MapBlueprint>(maps);
    }

    internal void DeleteSelectedMap()
    {
        if (SelectedMap is null)
            return;

        _mapService.Delete(SelectedMap);
        Maps.Remove(SelectedMap);
    }

    internal void SaveSelectedMap(string identifier, ITile[] board)
    {
        var map = new MapBlueprint
        {
            Figures = board.Select(x => new FigureBlueprint
            {
                Hp = x.Figure.Hp,
                PlayerId = x.Figure.Owner.Id,
                UnitName = x.Figure.FigureType.UnitName
            }).ToArray(),
            MapPath = $"Resources/Maps/{identifier}.map",
            PreviewPath = $"./Resources/Maps/{identifier}.png",
            PlayersCount = _playerService.PlayersCount,
            StartingPlayer = _playerService.CurrentPlayer.Id,
        };

        _mapService.Save(map);
    }

    public void Dispose()
    {
        _mapService.MapsChanged -= OnMapsChanged;
    }
}
