using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintCodeNet.Models.Variables
{
    public interface IField
    {

    }
    public class VariableItem<T> : IField
    {
        public Type Type
        {
            get
            {
                return typeof(T);
            }
        }
        public VariableType VarType { get; set; }
        public InputType InType { get; set; }
        public T Variable { get; set; }
    }
}
