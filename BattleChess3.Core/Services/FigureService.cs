using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BattleChess3.Core.Figures;

namespace BattleChess3.Core.Services
{
    public class FigureService
    {
        private readonly Dictionary<string, IFigureType> _figuresDictionary;
        public IFigureGroup[] FigureGroups { get; }
        
        public FigureService()
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
        }

        /// <summary>
        /// Gets first figure which name is given string
        /// </summary>
        public IFigureType GetFigureFromName(string text)
            => _figuresDictionary[text];
    }
}