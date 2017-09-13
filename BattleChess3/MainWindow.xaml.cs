using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BattleChess3.Game;
using BattleChess3.GameData;
using BattleChess3.GameData.Figures;
using BattleChess3.Properties;
using Button = System.Windows.Controls.Button;
using FontFamily = System.Windows.Media.FontFamily;
using ListBox = System.Windows.Controls.ListBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using Style = BattleChess3.GameData.Styles.Style;

namespace BattleChess3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            TextElement.FontFamilyProperty.OverrideMetadata(
                typeof(TextElement),
                new FrameworkPropertyMetadata(
                    new FontFamily("Edwardian Script ITC")));

            TextBlock.FontFamilyProperty.OverrideMetadata(
                typeof(TextBlock),
                new FrameworkPropertyMetadata(
                    new FontFamily("Edwardian Script ITC")));
        }

        /// <summary>
        /// Called when new game is clicked
        /// </summary>
        private void OnNewGameClick(object sender, RoutedEventArgs e)
        {
            if (Session.SelectedMap.Figure != null)
            {
                GameTab.IsEnabled = true;
                Session.LoadMap();
                Session.SetBindedBoard();
                GameTab.IsSelected = true;
            }
        }

        private void OnOptionsClick(object sender, RoutedEventArgs e)
        {
            OptionsTab.IsSelected = true;
        }

        private void OnQuitApplicationClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnSaveMapClick(object sender, RoutedEventArgs e)
        {
            if (Session.Board.All(column => column != null))
            {
                var rnd = new Random();
                var randomName = rnd.Next(0, int.MaxValue).ToString();
                SaveMap(randomName);
                SetMapToMapsHolder(randomName);
            }
        }

        private void SetMapToMapsHolder(string randomName)
        {
            var emptyMap = MapsHolder.FindFirstEmptyMap();
            emptyMap.Name = Directory.GetCurrentDirectory() + $"\\Maps\\{randomName}.txt";
            emptyMap.StartingPlayer = Session.WhooseTurn;
            var tiles = new string[8][];
            for (var i = 0; i < 8; i++)
            {
                tiles[i] = new string[8];
            }
            var lines = File.ReadAllLines(emptyMap.Name);
            for (var i = 0; i < 8; i++)
            {
                var tile = lines[7 - i].Split(' ');
                for (var j = 0; j < 8; j++)
                {
                    tiles[i][j] = tile[j];
                }
            }
            emptyMap.Figure = tiles;
            emptyMap.PreviewPath = Directory.GetCurrentDirectory() + $"\\MapsPreviews\\{randomName}.png";
        }

        private void SaveMap(string randomName)
        {
            SaveToPng(BoardControl, $"MapsPreviews\\{randomName}.png");
            var boardStrings = new string[10];
            for (var i = 0; i < 8; i++)
            {
                boardStrings[i] = "";
                for (var j = 0; j < 8; j++)
                {
                    var figure = Session.BoardColumns[j].ColumnFigures[7-i];
                    if (figure.Color == Resource.Neutral)
                    {
                        boardStrings[i] += figure.FigureType.UnitName + " ";
                    }
                    else
                    {
                        boardStrings[i] += figure.Color + figure.FigureType.UnitName + " ";
                    }
                }
            }
            boardStrings[8] = $"MapsPreviews\\{randomName}.png";
            boardStrings[9] = Session.WhooseTurn;
            using (var outputFile = new StreamWriter(Directory.GetCurrentDirectory() + $"\\Maps\\{randomName}.txt"))
            {
                foreach (var line in boardStrings)
                {
                    outputFile.WriteLine(line);
                }
            }
        }
        
        private void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            SaveUsingEncoder(visual, fileName, encoder);
        }
        
        private void SaveUsingEncoder(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.Create(fileName))
            {
                encoder.Save(stream);
            }
        }

        private void DeleteMap(object sender, RoutedEventArgs e)
        {
            if (Session.SelectedMap.Name != null)
            {
                File.Delete(Session.SelectedMap.Name);
                Session.SelectedMap.Dispose();
            }
        }
    }
}
