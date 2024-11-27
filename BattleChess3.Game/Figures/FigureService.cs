using System.Reflection;

namespace BattleChess3.Game.Figures;

internal class FigureService : IFigureService
{
    private readonly FileSystemWatcher _watcher;

    private IFigureGroup[] _figureGroups = Array.Empty<IFigureGroup>();
    private Dictionary<string, IFigureType> _figuresDictionary = new();

    public FigureService()
    {
        _watcher = new FileSystemWatcher(".");

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

        _watcher.Filter = "*Figures.dll";
        _watcher.IncludeSubdirectories = true;
        _watcher.EnableRaisingEvents = true;

        Task.Run(ReloadFigures);
    }

    public event EventHandler<IList<IFigureGroup>>? FigureGroupsChanged;

    public IList<IFigureGroup> GetFigureGroups()
    {
        return _figureGroups;
    }

    public IFigureType GetFigureFromName(string text)
    {
        return _figuresDictionary[text];
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        ReloadFigures();
    }

    private void ReloadFigures()
    {
        _figureGroups = Directory.GetFiles(".", "*Figures.dll")
            .Select(path => Assembly.LoadFile(Path.GetFullPath(path)))
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.GetInterfaces().Any(x => x == typeof(IFigureGroup)))
            .Select(type => (IFigureGroup)Activator.CreateInstance(type)!)
            .ToArray();

        _figuresDictionary = _figureGroups.SelectMany(group => group.FigureTypes)
            .ToDictionary(figure => figure.UnitName, figure => figure);
        FigureGroupsChanged?.Invoke(this, _figureGroups);
    }
}