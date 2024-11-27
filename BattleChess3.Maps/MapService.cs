using BattleChess3.Maps.Utilities;
using Newtonsoft.Json;

namespace BattleChess3.Maps;

internal class MapService : IMapService
{
    private readonly FileSystemWatcher _watcher;

    private MapBlueprint[] _maps = Array.Empty<MapBlueprint>();

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

    public event EventHandler<IList<MapBlueprint>>? MapsChanged;

    public IList<MapBlueprint> GetCurrentMaps()
    {
        return _maps;
    }

    public void Delete(MapBlueprint selectedMap)
    {
        File.Delete(selectedMap.MapPath);
    }

    public void Save(MapBlueprint map)
    {
        var text = JsonConvert.SerializeObject(map);
        text = CompressionHelper.Compress(text);
        File.WriteAllText(map.MapPath, text);
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
                var text = File.ReadAllText(Path.GetFullPath(path));
                text = CompressionHelper.Decompress(text);
                return JsonConvert.DeserializeObject<MapBlueprint>(text);
            })
            .Where(x => x is not null)
            .Select(x => x!)
            .OrderByDescending(x => x.MapPath)
            .ToArray();

        Directory.GetFiles("Resources/Maps", "*.png")
            .Select(Path.GetFileNameWithoutExtension)
            .Except(Directory.GetFiles("Resources/Maps", "*.map")
                .Select(Path.GetFileNameWithoutExtension))
            .ToList()
            .ForEach(x =>
            {
                var fileName = Path.GetFullPath($"Resources/Maps/{x}.png");
                if (!IsFileLocked(new FileInfo(fileName)))
                {
                    File.Delete(fileName);
                }
            });

        MapsChanged?.Invoke(this, _maps);
    }

    private static bool IsFileLocked(FileInfo file)
    {
        try
        {
            using var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
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