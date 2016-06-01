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
    /// Interaction logic for Variables.xaml
    /// </summary>
    public partial class Variables : UserControl
    {
        public Variables()
        {
            InitializeComponent();
            List<PaintCodeNet.Models.Variables.IField> col = new List<PaintCodeNet.Models.Variables.IField>();
            var someItem = new PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Expression>();
            someItem.Variable = new Models.Variables.Expression() { Name = "Expression", Value = "Some test" };
            col.Add(someItem);
            col.Add(new PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Number>() { Variable = new Models.Variables.Number() { Name = "Number", Value = 23 } });
            col.Add(new PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Fraction>() { Variable = new Models.Variables.Fraction() { Name = "Fraction", Value = 0.5F } });
            col.Add(new PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Angle>() { Variable = new Models.Variables.Angle() { Name = "Angle", Value = 90 } });
            col.Add(new PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Text>() { Variable = new Models.Variables.Text() { Name = "Text", Value = "Some text" } });
            col.Add(new PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Boolean>() { Variable = new Models.Variables.Boolean() { Name = "Boolean", Value = true } });
            col.Add(new PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Point>() { Variable = new Models.Variables.Point() { Name = "Point", X = 24, Y = 35 } });
            col.Add(new PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Size>() { Variable = new Models.Variables.Size() { Name = "Size", W = 14, H = 35 } });
            col.Add(new PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Rectangle>() { Variable = new Models.Variables.Rectangle() { Name = "Rectangle", X = 24, Y = 35, W = 14, H = 35 } });
            VariablesTreeView.ItemsSource = col;
        }
    }
}
