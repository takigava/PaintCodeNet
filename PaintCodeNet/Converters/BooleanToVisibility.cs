﻿using System;
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
    public class BooleanToVisibility : ConverterBase<bool, Visibility>
    {
        public override Visibility Convert(bool x)
        {
            return x ? Visibility.Visible : Visibility.Collapsed;
        }
        public override bool Convert(Visibility x)
        {
            return x == Visibility.Visible;
        }
    }
}
