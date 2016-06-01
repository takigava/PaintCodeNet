using PaintCodeNet.Models;
using PaintCodeNet.Models.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PaintCodeNet.TemplateSelectors
{
    public class VariableTreeViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ExpressionTreeViewDataTemplate { get; set; }
        public DataTemplate NumberTreeViewDataTemplate { get; set; }
        public DataTemplate FractionTreeViewDataTemplate { get; set; }
        public DataTemplate AngleTreeViewDataTemplate { get; set; }
        public DataTemplate TextTreeViewDataTemplate { get; set; }
        public DataTemplate BooleanTreeViewDataTemplate { get; set; }
        public DataTemplate PointTreeViewDataTemplate { get; set; }
        public DataTemplate SizeTreeViewDataTemplate { get; set; }
        public DataTemplate RectangleTreeViewDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            //variableItem = (VariableItem)item;
            if (item is PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Expression>)
            {
                return GetTemplate(VariableType.Expression);
            }
            if (item is PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Number>)
            {
                return GetTemplate(VariableType.Number);
            }
            if (item is PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Fraction>)
            {
                return GetTemplate(VariableType.Fraction);
            }
            if (item is PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Angle>)
            {
                return GetTemplate(VariableType.Angle);
            }
            if (item is PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Text>)
            {
                return GetTemplate(VariableType.Text);
            }
            if (item is PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Boolean>)
            {
                return GetTemplate(VariableType.Boolean);
            }
            if (item is PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Point>)
            {
                return GetTemplate(VariableType.Point);
            }
            if (item is PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Size>)
            {
                return GetTemplate(VariableType.Size);
            }
            if (item is PaintCodeNet.Models.Variables.VariableItem<PaintCodeNet.Models.Variables.Rectangle>)
            {
                return GetTemplate(VariableType.Rectangle);
            }
            return null;
        }

        private DataTemplate GetTemplate(VariableType type)
        {
            switch (type)
            {
                case VariableType.Expression:
                    return ExpressionTreeViewDataTemplate;
                case VariableType.Number:
                    return NumberTreeViewDataTemplate;
                case VariableType.Fraction:
                    return FractionTreeViewDataTemplate;
                case VariableType.Angle:
                    return AngleTreeViewDataTemplate;
                case VariableType.Text:
                    return TextTreeViewDataTemplate;
                case VariableType.Boolean:
                    return BooleanTreeViewDataTemplate;
                case VariableType.Point:
                    return PointTreeViewDataTemplate;
                case VariableType.Size:
                    return SizeTreeViewDataTemplate;
                case VariableType.Rectangle:
                    return RectangleTreeViewDataTemplate;
                default:
                    return null;
            }
        }
    }
}
