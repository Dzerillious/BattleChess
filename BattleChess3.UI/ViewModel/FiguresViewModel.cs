using BattleChess3.Core.Model.Figures;
using BattleChess3.UI.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleChess3.UI.ViewModel;

public class FiguresViewModel : ViewModelBase
{
    private readonly IFigureService _figureService;

    private IFigureGroup _selectedFigureGroup = EmptyFigureGroup.Instance;
    public IFigureGroup SelectedFigureGroup
    {
        get => _selectedFigureGroup;
        set
        {
            if (value is null)
                value = EmptyFigureGroup.Instance;

            Set(ref _selectedFigureGroup, value);
        }
    }

    private IList<IFigureGroup> _figureGroups = Array.Empty<IFigureGroup>();
    public IList<IFigureGroup> FigureGroups
    {
        get => _figureGroups;
        set
        {
            Set(ref _figureGroups, value);
            if (!_figureGroups.Any(x => x.ShownName == _selectedFigureGroup.ShownName))
            {
                SelectedFigureGroup = _figureGroups.FirstOrDefault()
                    ?? EmptyFigureGroup.Instance;
            }
        }
    }

    public RelayCommand<IFigureGroup> SelectFigureGroupCommand { get; }

    public FiguresViewModel(IFigureService figureService)
    {
        _figureService = figureService;
        FigureGroups = _figureService.GetFigureGroups();
        _figureService.FigureGroupsChanged += OnFigureGroupsChanged;

        SelectFigureGroupCommand = new RelayCommand<IFigureGroup>(group => SelectedFigureGroup = group);
    }


    public void OnFigureGroupsChanged(object sender, IList<IFigureGroup> groups)
    {
        FigureGroups = groups;
    }
}
