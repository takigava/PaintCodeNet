using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;
using System.Globalization;
using System.Windows.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaintCodeNet.Converters
{
    public class StringFormat : ConverterBase<object, string>
    {
        public string Format { get; set; }

        public override string Convert(object x)
        {
            return string.Format(Format, x);
        }
        public override object Convert(string x)
        {
            throw new NotSupportedException();
        }
    }
}
