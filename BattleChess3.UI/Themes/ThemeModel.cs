using System.Collections;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Media;

namespace BattleChess3.UI.Themes;

public class ThemeModel
{
    public static readonly ThemeModel None = new();

    private ThemeModel()
    {
        Name = string.Empty;
        Preview = (ImageSource?)ResourceDictionary["Preview"];
    }

    public ThemeModel(string assemblyPath)
    {
        LoadResources(assemblyPath);
        Preview = (ImageSource?)ResourceDictionary["Preview"];

        Name = Path.GetFileNameWithoutExtension(assemblyPath);
    }

    public string Name { get; }
    public ImageSource? Preview { get; }
    public ResourceDictionary ResourceDictionary { get; } = new();

    private void LoadResources(string assemblyPath)
    {
        var assembly = Assembly.LoadFile(assemblyPath);
        var stream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".g.resources");
        if (stream == null)
        {
            return;
        }

        var resourceReader = new ResourceReader(stream);
        foreach (DictionaryEntry? resource in resourceReader)
        {
            if (resource is not { } entry)
            {
                return;
            }

            var keyName = entry.Key.ToString() ?? string.Empty;
            if (!keyName.EndsWith(".baml", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var uri = new Uri("/" + assembly.GetName().Name + ";component/" + keyName.Replace(".baml", ".xaml"),
                UriKind.Relative);
            var dictionary = (ResourceDictionary)Application.LoadComponent(uri);
            foreach (var keyObject in dictionary.Keys)
            {
                if (keyObject is null)
                {
                    return;
                }

                ResourceDictionary[keyObject] = dictionary[keyObject];
            }
        }
    }
}