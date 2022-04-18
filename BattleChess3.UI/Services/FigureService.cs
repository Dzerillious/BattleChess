using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BattleChess3.Core.Model.Figures;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BattleChess3.UI.Services;

public class FigureService : ViewModelBase
{
    private IFigureGroup _selectedFigureGroup = EmptyFigureGroup.Instance;
    public IFigureGroup SelectedFigureGroup
    {
        get => _selectedFigureGroup;
        set => Set(ref _selectedFigureGroup, value);
    }
    
    private Dictionary<string, IFigureType> _figuresDictionary = new Dictionary<string, IFigureType>();

    private IFigureGroup[] _figureGroups = Array.Empty<IFigureGroup>();
    public IFigureGroup[] FigureGroups
    {
        get => _figureGroups;
        set => Set(ref _figureGroups, value);
    }
    
    public RelayCommand<IFigureGroup> SelectFigureGroupCommand { get; }

    public FigureService()
    {
        Task.Run(ReloadFigures);
        SelectFigureGroupCommand = new RelayCommand<IFigureGroup>(group => SelectedFigureGroup = group);
    }

    public void ReloadFigures()
    {
        var groupType = typeof(IFigureGroup);
        
        FigureGroups = Directory.GetFiles(".", "*Figures.dll")
                                .Select(path => Assembly.LoadFile(Path.GetFullPath(path)))
                                .SelectMany(assembly => assembly.GetTypes())
                                .Where(type => type.GetInterfaces().Any(x => x == groupType))
                                .Select(type => (IFigureGroup) Activator.CreateInstance(type)!)
                                .ToArray();

        _figuresDictionary = FigureGroups.SelectMany(group => group.FigureTypes)
                                         .ToDictionary(figure => figure.UnitName, figure => figure);
        SelectedFigureGroup = FigureGroups.First();
    }

    public IFigureType GetFigureFromName(string text)
        => _figuresDictionary[text];
}
