using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BattleChess3.Core.Model;
using BattleChess3.Core.Utilities;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace BattleChess3.UI.Services;

public class MapService : ViewModelBase, IMapService
{
    private MapBlueprint[] _maps = Array.Empty<MapBlueprint>();

    public event EventHandler<IList<MapBlueprint>>? MapsChanged;

    public MapService()
    {
        using var watcher = new FileSystemWatcher("Resources/Maps");

        watcher.NotifyFilter = NotifyFilters.Attributes
                             | NotifyFilters.CreationTime
                             | NotifyFilters.DirectoryName
                             | NotifyFilters.FileName
                             | NotifyFilters.LastAccess
                             | NotifyFilters.LastWrite
                             | NotifyFilters.Security
                             | NotifyFilters.Size;

        watcher.Changed += OnChanged;
        watcher.Created += OnChanged;
        watcher.Deleted += OnChanged;
        watcher.Renamed += OnChanged;

        watcher.Filter = "*.map";
        watcher.IncludeSubdirectories = true;
        watcher.EnableRaisingEvents = true;

        Task.Run(() => ReloadMaps());
    }

    public IList<MapBlueprint> GetCurrentMaps()
    {
        return _maps;
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        ReloadMaps();
    }

    private void ReloadMaps()
    {
        _maps = Directory.GetFiles("Resources/Maps", "*.map")
                        .Select(path =>
                        {
                            string text = File.ReadAllText(Path.GetFullPath(path));
                            text = CompressionHelper.Decompress(text);
                            return JsonConvert.DeserializeObject<MapBlueprint>(text);
                        })
                        .ToArray();
        MapsChanged?.Invoke(this, _maps);
    }
}
