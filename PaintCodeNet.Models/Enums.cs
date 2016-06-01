using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintCodeNet.Models
{
    public enum VariableType
    {
        Expression,
        Number,
        Fraction,
        Angle,
        Text,
        Boolean,
        Point,
        Size,
        Rectangle
    }

    public enum InputType 
    {
        None,
        StyleKit,
        LocalVariable,
        Parameter
    }
}
