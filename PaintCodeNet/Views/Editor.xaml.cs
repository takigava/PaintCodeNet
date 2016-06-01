using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : UserControl
    {
        public Editor()
        {
            InitializeComponent();

            var path = new System.Windows.Shapes.Path();
            path.Stroke = System.Windows.Media.Brushes.Black;
            path.Fill = System.Windows.Media.Brushes.Firebrick;
            path.StrokeThickness = 1;

            var combinedGeometry = new CombinedGeometry(GeometryCombineMode.Xor, new EllipseGeometry(new System.Windows.Point(75, 75), 50, 50), new EllipseGeometry(new System.Windows.Point(125, 75), 50, 50));
            path.Data = combinedGeometry;
            Canvas2.Children.Add(path);
        }

        ScaleTransform scaleTransform = new ScaleTransform();      //---------> object for Scale-Transform
        const double ScaleRate = 1.05;

        private void Canvas2_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //if (e.Delta > 0)
            //{
            //    scaleTransform.ScaleX *= ScaleRate;
            //    scaleTransform.ScaleY *= ScaleRate;
            //    Canvas2.ZoomValue *= ScaleRate;
            //}
            //else
            //{
            //    scaleTransform.ScaleX /= ScaleRate;
            //    scaleTransform.ScaleY /= ScaleRate;
            //    Canvas2.ZoomValue /= ScaleRate;
            //}
            //Canvas2.RenderTransform = scaleTransform;
            //Canvas2.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            var element = (FrameworkElement)sender;
            var transform = (MatrixTransform)element.LayoutTransform;
            var matrix = transform.Matrix;
            var scale = e.Delta >= 0d ? 1.1 : (1d / 1.1);

            matrix.Scale(ScaleRate, ScaleRate);
            transform.Matrix = matrix;
            if (e.Delta > 0)
            {
                Canvas2.ZoomValue *= ScaleRate;
            }
            else
            {
                Canvas2.ZoomValue /= ScaleRate;
            }
            
            e.Handled = true;

        }

        bool isDragged = false;
        System.Windows.Point _last = new System.Windows.Point();
        void Canvas2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            Canvas2.ReleaseMouseCapture();
            isDragged = false;
        }

        void Canvas2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragged == false)
                return;

            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed && Canvas2.IsMouseCaptured)
            {

                var pos = e.GetPosition(this);
                var element = (FrameworkElement)sender;
                var transform = (MatrixTransform)element.LayoutTransform;
                var matrix = transform.Matrix;
                matrix.Translate(pos.X - _last.X, pos.Y - _last.Y);
                transform.Matrix = matrix;
                _last = pos;

            }
        }
        void Canvas2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            Canvas2.CaptureMouse();
            //_last = e.GetPosition(canvas);
            _last = e.GetPosition(this);

            isDragged = true;
        }
    }
}
