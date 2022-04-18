using BattleChess3.UI.Utilities;
using BattleChess3.UI.ViewModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BattleChess3.UI.Views;

public partial class MainWindow
{
    public MainWindowViewModel? ViewModel { get; private set; }

    public MainWindow()
    {
        InitializeComponent();
        TextElement.FontFamilyProperty.OverrideMetadata(
            typeof(TextElement),
            new FrameworkPropertyMetadata(
                new FontFamily("Britannic Bold")));

        TextBlock.FontFamilyProperty.OverrideMetadata(
            typeof(TextBlock),
            new FrameworkPropertyMetadata(
                new FontFamily("Britannic Bold")));

        Loaded += MainWindow_Loaded;
        DataContextChanged += MainWindow_DataContextChanged;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        ViewModel = (MainWindowViewModel) DataContext;
        ViewModel.RequestSavePreview += ViewModel_RequestSavePreview;
    }

    private void MainWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (ViewModel is not null)
        {
            ViewModel.RequestSavePreview -= ViewModel_RequestSavePreview;
        }

        ViewModel = (MainWindowViewModel) DataContext;
        ViewModel.RequestSavePreview += ViewModel_RequestSavePreview;
    }

    private void ViewModel_RequestSavePreview(object? sender, string identifier)
    {
        SaveBoardPreview($"Resources\\Maps\\{identifier}.png");
    }

    public void SaveBoardPreview(string fileName)
    {
        var dpi = VisualTreeHelper.GetDpi(GameBoard);
        RenderTargetBitmap bmp = new RenderTargetBitmap(
            (int)GameBoard.ActualWidth, 
            (int)GameBoard.ActualHeight,
            96,
            96, 
            PixelFormats.Pbgra32);

        bmp.Render(GameBoard);

        var encoder = new PngBitmapEncoder();
        BitmapFrame frame = BitmapFrame.Create(bmp);
        encoder.Frames.Add(frame);

        using var stream = File.Create(fileName);
        encoder.Save(stream);
    }
}
