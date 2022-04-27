using BattleChess3.Core.Model.Figures;
using BattleChess3.UI.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BattleChess3.UI.Views;

public partial class GameBoardControl
{
    public GameBoardControl()
    {
        InitializeComponent();
    }

    private void Image_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent("figureData"))
        {
            var figureBlueprint = (FigureBlueprint)e.Data.GetData("figureData");
            Image image = (Image) sender;
            ITileViewModel tileViewModel = (ITileViewModel) image.DataContext;

            ItemsControl itemsControl = FindAnchestor<ItemsControl>((DependencyObject)e.OriginalSource);
            BoardViewModel boardView = (BoardViewModel) itemsControl.DataContext;

            boardView.CreateFigure(tileViewModel, figureBlueprint);
        }
    }

    private void Image_DragEnter(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent("figureData") ||
           sender == e.Source)
        {
            e.Effects = DragDropEffects.Copy;
        }
    }

    private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
    {
        var button = (Button)sender;
        var tileViewModel = (ITileViewModel)button.DataContext;
        var itemsControl = FindAnchestor<ItemsControl>(button);
        var boardViewModel = (BoardViewModel)itemsControl.DataContext;
        boardViewModel.MouseEnterCommand.Execute(tileViewModel);
    }

    private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
        var button = (Button)sender;
        var tileViewModel = (ITileViewModel)button.DataContext;
        var itemsControl = FindAnchestor<ItemsControl>(button);
        var boardViewModel = (BoardViewModel)itemsControl.DataContext;
        boardViewModel.MouseExitCommand.Execute(tileViewModel);
    }

    private static T FindAnchestor<T>(DependencyObject current)
        where T : DependencyObject
    {
        do
        {
            if (current is T)
            {
                return (T)current;
            }
            current = VisualTreeHelper.GetParent(current);
        }
        while (current != null);
        return default;
    }
}
