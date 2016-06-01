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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaintCodeNet.Views
{
    /// <summary>
    /// Interaction logic for CustomCanvas.xaml
    /// </summary>
    public partial class CustomCanvas : Canvas
    {
        #region GridWidth
        public static readonly DependencyProperty GridWidthProperty =
    DependencyProperty.Register("GridWidth", typeof(double), typeof(CustomCanvas),
    new PropertyMetadata(1.0, GridWidthPropertyChanged));

        public double GridWidth
        {
            get { return (double)GetValue(GridWidthProperty); }
            set { SetValue(GridWidthProperty, value); }
        }

        private void GridWidthPropertyChanged(double gridWidth)
        {
            //...
        }

        private static void GridWidthPropertyChanged(
    DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomCanvas)d).GridWidthPropertyChanged((double)e.NewValue);
        }

        #endregion

        #region GridHeight
        public static readonly DependencyProperty GridHeightProperty =
    DependencyProperty.Register("GridHeight", typeof(double), typeof(CustomCanvas),
    new PropertyMetadata(1.0, GridHeightPropertyChanged));

        public double GridHeight
        {
            get { return (double)GetValue(GridHeightProperty); }
            set { SetValue(GridHeightProperty, value); }
        }

        private void GridHeightPropertyChanged(double gridHeight)
        {
            //...
        }

        private static void GridHeightPropertyChanged(
    DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomCanvas)d).GridHeightPropertyChanged((double)e.NewValue);
        }

        #endregion

        #region IsGridVisible
        public static readonly DependencyProperty IsGridVisibleProperty =
    DependencyProperty.Register("IsGridVisible", typeof(bool), typeof(CustomCanvas),
    new PropertyMetadata(false, IsGridVisiblePropertyChanged));

        public bool IsGridVisible
        {
            get { return (bool)GetValue(IsGridVisibleProperty); }
            set { SetValue(IsGridVisibleProperty, value); }
        }

        private void IsGridVisiblePropertyChanged(bool isGridVisible)
        {
            //...
        }

        private static void IsGridVisiblePropertyChanged(
    DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomCanvas)d).IsGridVisiblePropertyChanged((bool)e.NewValue);
        }

        #endregion

        #region ZoomValue
        public static readonly DependencyProperty ZoomValueProperty =
    DependencyProperty.Register("ZoomValue", typeof(double), typeof(CustomCanvas),
    new PropertyMetadata(1.0, ZoomValuePropertyPropertyChanged));

        public double ZoomValue
        {
            get { return (double)GetValue(ZoomValueProperty); }
            set { SetValue(ZoomValueProperty, value); }
        }

        private void ZoomValuePropertyPropertyChanged(double zoomValue)
        {
            this.InvalidateVisual();
        }

        private static void ZoomValuePropertyPropertyChanged(
    DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomCanvas)d).ZoomValuePropertyPropertyChanged((double)e.NewValue);
        }

        #endregion

        protected override void OnRender(System.Windows.Media.DrawingContext dc)
        {
            base.OnRender(dc);

            if (this.IsGridVisible)
            {
                // Draw GridLines
                Pen pen = new Pen(new SolidColorBrush(System.Windows.Media.Colors.Brown), 1/this.ZoomValue);
                pen.DashStyle = DashStyles.Dash;

                for (double x = 0; x < this.ActualWidth; x += this.GridWidth)
                {
                    dc.DrawLine(pen, new Point(x, 0), new Point(x, this.ActualHeight));
                }

                for (double y = 0; y < this.ActualHeight; y += this.GridHeight)
                {
                    dc.DrawLine(pen, new Point(0, y), new Point(this.ActualWidth, y));
                }
            }
        }
    }
}
