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
    private readonly FileSystemWatcher _watcher;

    private MapBlueprint[] _maps = Array.Empty<MapBlueprint>();

    public event EventHandler<IList<MapBlueprint>>? MapsChanged;

    public MapService()
    {
        _watcher = new FileSystemWatcher("Resources/Maps");

        _watcher.NotifyFilter = NotifyFilters.Attributes
                             | NotifyFilters.CreationTime
                             | NotifyFilters.DirectoryName
                             | NotifyFilters.FileName
                             | NotifyFilters.LastAccess
                             | NotifyFilters.LastWrite
                             | NotifyFilters.Security
                             | NotifyFilters.Size;

        _watcher.Changed += OnChanged;
        _watcher.Created += OnChanged;
        _watcher.Deleted += OnChanged;
        _watcher.Renamed += OnChanged;

        _watcher.Filter = "*.map";
        _watcher.IncludeSubdirectories = true;
        _watcher.EnableRaisingEvents = true;

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
            .Where(path => File.Exists(Path.GetFullPath(path)))
            .Select(path =>
            {
                string text = File.ReadAllText(Path.GetFullPath(path));
                text = CompressionHelper.Decompress(text);
                return JsonConvert.DeserializeObject<MapBlueprint>(text);
            })
            .OrderByDescending(map => map.MapPath)
            .ToArray();

        Directory.GetFiles("Resources/Maps", "*.png")
            .Select(x => Path.GetFileNameWithoutExtension(x))
            .Except(Directory.GetFiles("Resources/Maps", "*.map")
                .Select(x => Path.GetFileNameWithoutExtension(x)))
            .ToList()
            .ForEach(x =>
            {
                var fileName = Path.GetFullPath($"Resources/Maps/{x}.png");
                if (!IsFileLocked(new FileInfo(fileName)))
                    File.Delete(fileName);
            });

        MapsChanged?.Invoke(this, _maps);
    }

    public void Delete(MapBlueprint selectedMap)
    {
        File.Delete(selectedMap.MapPath);
    }

    public void Save(MapBlueprint map)
    {
        string text = JsonConvert.SerializeObject(map);
        text = CompressionHelper.Compress(text);
        File.WriteAllText(map.MapPath, text);
    }

    protected virtual bool IsFileLocked(FileInfo file)
    {
        try
        {
            using FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            stream.Close();
        }
        catch (IOException)
        {
            //the file is unavailable because it is:
            //still being written to
            //or being processed by another thread
            //or does not exist (has already been processed)
            return true;
        }

        //file is not locked
        return false;
    }
}
