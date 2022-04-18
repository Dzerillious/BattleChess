using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.UI.Services;

public class FigureService : IFigureService
{
    private readonly FileSystemWatcher _watcher;

    private IFigureGroup[] _figureGroups = Array.Empty<IFigureGroup>();
    private Dictionary<string, IFigureType> _figuresDictionary = new Dictionary<string, IFigureType>();

    public event EventHandler<IList<IFigureGroup>>? FigureGroupsChanged;

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

        Task.Run(() => ReloadFigures());
    }

    public IList<IFigureGroup> GetCurrentMaps()
    {
        return _figureGroups;
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

    public IList<IFigureGroup> GetFigureGroups()
        => _figureGroups;

    public IFigureType GetFigureFromName(string text)
        => _figuresDictionary[text];
}
