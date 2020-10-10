using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BattleChess3.Core.Model.Figure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BattleChess3.UI.Services
{
    public class FigureService : ViewModelBase
    {
        private Dictionary<string, IFigureType> _figuresDictionary;

        private IFigureGroup[] _figureGroups;
        public IFigureGroup[] FigureGroups
        {
            get => _figureGroups;
            set => Set(ref _figureGroups, value);
        }

        private IFigureGroup _selectedFigureGroup;
        public IFigureGroup SelectedFigureGroup
        {
            get => _selectedFigureGroup;
            set => Set(ref _selectedFigureGroup, value);
        }
        
        public RelayCommand<IFigureGroup> SelectFigureGroupCommand { get; private set; }

        public FigureService()
        {
            Task.Run(ReloadFigures);
            SelectFigureGroupCommand = new RelayCommand<IFigureGroup>(group => SelectedFigureGroup = group);
        }

        public void ReloadFigures()
        {
            var groupType = typeof(IFigureGroup);
            DirectoryInfo directory = new DirectoryInfo("FigureSets");
            var files = directory.GetFiles("*.dll")
                                 .Select(file => Path.GetFileNameWithoutExtension(file.Name));

            FigureGroups = files.Select(Assembly.Load)
                                .SelectMany(assembly => assembly.GetTypes())
                                .Where(type => type.GetInterfaces().Any(x => x == groupType))
                                .Select(type => (IFigureGroup) Activator.CreateInstance(type)!)
                                .ToArray();

            _figuresDictionary = FigureGroups.SelectMany(group => group.GroupFigures)
                                             .ToDictionary(figure => figure.UnitName, figure => figure);
            SelectedFigureGroup = FigureGroups.First();
        }

        public IFigureType GetFigureFromName(string text)
            => _figuresDictionary[text];
    }
}