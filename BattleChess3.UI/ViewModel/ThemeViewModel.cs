using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Media;

namespace BattleChess3.UI.ViewModel
{
    public class ThemeViewModel
    {
        public static readonly ThemeViewModel None = new ThemeViewModel();

        public string Name { get; }
        public ImageSource Preview { get; }
        public ResourceDictionary ResourceDictionary { get; } = new ResourceDictionary();

        public ThemeViewModel()
        {
            Name = string.Empty;
            Preview = (ImageSource) ResourceDictionary["Preview"];
        }

        public ThemeViewModel(string assemblyPath)
        {
            LoadResources(assemblyPath);
            Preview = (ImageSource) ResourceDictionary["Preview"];

            Name = Path.GetFileNameWithoutExtension(assemblyPath);
        }

        private void LoadResources(string assemblyPath)
        {
            var assembly = Assembly.LoadFile(assemblyPath);
            var stream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".g.resources");
            if (stream == null) return;
            var resourceReader = new ResourceReader(stream);

            foreach (DictionaryEntry? resource in resourceReader)
            {
                if (!(resource is { } entry)) return;
                string keyName = entry.Key.ToString() ?? string.Empty;
                if (!keyName.EndsWith(".baml", StringComparison.OrdinalIgnoreCase)) continue;

                Uri uri = new Uri("/" + assembly.GetName().Name + ";component/" + keyName.Replace(".baml", ".xaml"),
                    UriKind.Relative);
                ResourceDictionary dictionary = (ResourceDictionary) Application.LoadComponent(uri);
                foreach (object? keyObject in dictionary.Keys)
                {
                    if (!(keyObject is { } key)) return;
                    ResourceDictionary[key] = dictionary[key];
                }
            }
        }
    }
}