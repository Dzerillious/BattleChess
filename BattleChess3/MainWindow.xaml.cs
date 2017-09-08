using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using BattleChess3.Figures;
using BattleChess3.Game;
using BattleChess3.Game.Styles;
using BattleChess3.Menu;
using BattleChess3.Properties;
using Button = System.Windows.Controls.Button;
using FontFamily = System.Windows.Media.FontFamily;
using ListBox = System.Windows.Controls.ListBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

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

        /// <summary>
        /// Called when selected map is changed
        /// </summary>
        private void OnSelectedMapChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox) sender;
            Session.SelectedMap = (Map)listBox.SelectedItem;
        }
        
        /// <summary>
        /// Called when chess tile button is clicked
        /// </summary>
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var figure = (BaseFigure) button.CommandParameter;
            Session.ClickedAtPosition(figure.Position);
        }

        /// <summary>
        /// Called when mouse enters chess tile
        /// </summary>
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            var button = (Button) sender;
            var figure = (BaseFigure) button.CommandParameter;
            Session.MouseOn.SelFigure = figure;
            Session.MouseOn.SelPosition = figure.Position;
        }

        private void OnSaveMapClick(object sender, RoutedEventArgs e)
        {
            var rnd = new Random();
            var randomName = rnd.Next(0, int.MaxValue).ToString();
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
            boardStrings[8] = Directory.GetCurrentDirectory() + $"\\MapsPreviews\\{randomName}.png";
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

        private void OnManualClick(object sender, RoutedEventArgs e)
        {
            ManualTab.IsSelected = true;
        }

        private void OnSelectedStyleChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox) sender;
            Session.SelectedStyle.ApplicationStyle = (IStyle) listBox.SelectedItem;
            InitializeComponent();
        }

        private void DeleteMap(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
