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
    /// Interaction logic for Gradients.xaml
    /// </summary>
    public partial class Gradients : UserControl
    {
        public Gradients()
        {
            InitializeComponent();
            GradientsTreeView.Items.Add(new TreeViewItem() { Header = "sdfgdfh" });
            GradientsTreeView.Items.Add(new TreeViewItem() { Header = "sdfgdfh1" });
            GradientsTreeView.Items.Add(new TreeViewItem() { Header = "sdfgdfh2" });
            GradientsTreeView.Items.Add(new TreeViewItem() { Header = "sdfgdfh3" });
            GradientsTreeView.Items.Add(new TreeViewItem() { Header = "sdfgdfh4" });
            GradientsTreeView.Items.Add(new TreeViewItem() { Header = "sdfgdfh5" });
            GradientsTreeView.Items.Add(new TreeViewItem() { Header = "sdfgdfh6" });
        }
    }
}
