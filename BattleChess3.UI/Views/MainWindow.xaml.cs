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
    private GameBoardControl _lastBoardControl;
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
        EditorBoard.RequestBringIntoView += EditorBoard_RequestBringIntoView;
        GameBoard.RequestBringIntoView += GameBoard_RequestBringIntoView;
    }

    private void GameBoard_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
    {
        _lastBoardControl = GameBoard;
    }

    private void EditorBoard_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
    {
        _lastBoardControl = EditorBoard;
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
        var dpi = VisualTreeHelper.GetDpi(_lastBoardControl);
        RenderTargetBitmap bmp = new RenderTargetBitmap(
            (int)_lastBoardControl.ActualWidth, 
            (int)_lastBoardControl.ActualHeight,
            96,
            96, 
            PixelFormats.Pbgra32);

        bmp.Render(_lastBoardControl);

        var encoder = new PngBitmapEncoder();
        BitmapFrame frame = BitmapFrame.Create(bmp);
        encoder.Frames.Add(frame);

        using var stream = File.Create(fileName);
        encoder.Save(stream);
    }
}
