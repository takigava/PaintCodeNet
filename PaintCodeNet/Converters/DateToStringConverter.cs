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
    public class DateToStringConverter : ConverterBase<DateTime, string>
    {
        public string Format { get; set; }

        public override DateTime Convert(string x)
        {
            return DateTime.ParseExact(x, Format ?? "o", null, DateTimeStyles.AllowWhiteSpaces);
        }
        public override string Convert(DateTime x)
        {
            return x.ToString(Format ?? "o");
        }
    }
}
