using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Media;

namespace BattleChess3.UI.ViewModel
{
    /// <summary>
    /// Interface for style of application
    /// </summary>
    public class Style
    {
        public readonly ResourceDictionary ResourceDictionary = new ResourceDictionary();
        
        public string Name { get; }

        /// <summary>
        /// Gets path of preview image of style
        /// </summary>
        public ImageSource Preview { get; }
        
        public Style(string assemblyPath)
        {
            LoadResources(assemblyPath);

            Name = Path.GetFileNameWithoutExtension(assemblyPath);
            Preview = (ImageSource) ResourceDictionary["Preview"];
        }

        private void LoadResources(string assemblyPath)
        {
            var assembly = Assembly.LoadFile(assemblyPath);
            var stream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".g.resources");
            if (stream == null) return;
            var resourceReader = new ResourceReader(stream);

            foreach (DictionaryEntry resource in resourceReader)
            {
                var keyName = resource.Key.ToString();
                if (!keyName.EndsWith(".baml")) continue;
                Uri uri = new Uri("/" + assembly.GetName().Name + ";component/" + keyName.Replace(".baml", ".xaml"), UriKind.Relative);
                ResourceDictionary dictionary = (ResourceDictionary) Application.LoadComponent(uri);
                foreach (object key in dictionary.Keys)
                    ResourceDictionary[key] = dictionary[key];
            }
        }
    }
}