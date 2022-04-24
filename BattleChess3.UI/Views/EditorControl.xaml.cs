using BattleChess3.Core.Model.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace BattleChess3.UI.Views
{
    /// <summary>
    /// Interaction logic for EditorControl.xaml
    /// </summary>
    public partial class EditorControl : UserControl
    {
        private Point _startPoint;

        public EditorControl()
        {
            InitializeComponent();
        }

        private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Store the mouse position
            _startPoint = e.GetPosition(null);
        }

        private void Image_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = _startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                Image image = (Image) sender;
                ItemsControl itemsControl = FindAnchestor<ItemsControl>((DependencyObject)e.OriginalSource);

                //// Find the data behind the ListViewItem
                var figureType = (IFigureType) itemsControl.DataContext;
                var imagePair = (KeyValuePair<int, Uri>) image.DataContext;
                var dataObject = new DataObject("figureData", new FigureBlueprint(imagePair.Key, figureType));

                //// Initialize the drag & drop operation
                DragDrop.DoDragDrop(image, dataObject, DragDropEffects.Move);
            }
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
}
