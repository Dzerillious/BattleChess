using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using BattleChess3.Game.Figures;
using BattleChess3.UI.ViewModel;

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
            var figureBlueprint = (FigureIdentifier)e.Data.GetData("figureData");
            var image = (Image)sender;
            var tileViewModel = (TileViewModel)image.DataContext;

            var itemsControl = FindAnchestor<ItemsControl>((DependencyObject)e.OriginalSource);
            var boardView = (BoardViewModel)itemsControl.DataContext;

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

    private void Button_MouseEnter(object sender, MouseEventArgs e)
    {
        var button = (Button)sender;
        var tileViewModel = (TileViewModel)button.DataContext;
        var itemsControl = FindAnchestor<ItemsControl>(button);
        var boardViewModel = (BoardViewModel)itemsControl.DataContext;
        boardViewModel.MouseEnterCommand.Execute(tileViewModel);
    }

    private void Button_MouseLeave(object sender, MouseEventArgs e)
    {
        var button = (Button)sender;
        var tileViewModel = (TileViewModel)button.DataContext;
        var itemsControl = FindAnchestor<ItemsControl>(button);
        var boardViewModel = (BoardViewModel)itemsControl.DataContext;
        boardViewModel.MouseExitCommand.Execute(tileViewModel);
    }

    private static T FindAnchestor<T>(DependencyObject parent)
        where T : DependencyObject
    {
        var current = parent;
        do
        {
            if (current is T dependencyObject)
            {
                return dependencyObject;
            }

            current = VisualTreeHelper.GetParent(current);
        } while (current != null);

        return default!;
    }
}