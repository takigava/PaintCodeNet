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
    /// <summary>Helpful base class for ValueConverters. The derived class only 
    /// needs to override the two Convert() abstract methods.</summary>
    /// <remarks>
    /// Standard IValueConverters require that you go out of your way to define an
    /// instance of the ValueConverter in your resources, which is very cumbersome.
    /// This class, however, is derived from MarkupExtension so that it can be used 
    /// without declaring a special "resource" for it (see example).
    /// <para/>
    /// BaseConverter doesn't distinguish between types "A" and "B". Either one
    /// can serve as the source type or target type, so Convert() and 
    /// ConvertFrom() do exactly the same thing: if the input is an A then it's 
    /// converted to a B; if the input is a B then it's converted to an A.
    /// </remarks>
    /// <example>
    /// <TextBlock Text="{Binding Date, Converter={local:DateToStringConverter Format='ddd hh:mm:ss tt'}}" />
    /// </example>
    public abstract class ConverterBase<A, B> : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        protected CultureInfo _culture;
        protected object _parameter;

        //<Rectangle Width="{Binding ElementName=otherElement, Path=(Canvas.Left), Converter={local:MultiplyConverter Factor=-0.5}}" />

        /// <summary>Converts a B to an A.</summary>
        /// <param name="x">Input to convert</param>
        /// <returns>An A object that represents the original B object.</returns>
        public abstract A Convert(B x);
        /// <summary>Converts an A to a B. See documentation of the other overload.</summary>
        public abstract B Convert(A x);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            _parameter = parameter;
            _culture = culture;

            object result = value;
            if (value is A)
                result = Convert((A)value);
            else if (value is B)
                result = Convert((B)value);

            // Check if the result is not nullable but the caller wants a nullable 
            // type. Unfortunately Convert.ChangeType throws an exception in this 
            // scenario. Handling this case allows BooleanToVisibility to be used
            // with CheckBox.IsChecked, which is nullable.
            Type valueTarget = Nullable.GetUnderlyingType(targetType);
            if (valueTarget != null)
            {
                if (result == null)
                    return Activator.CreateInstance(targetType);
                else
                {
                    result = System.Convert.ChangeType(result, valueTarget);
                    return Activator.CreateInstance(targetType, result);
                }
            }

            if (result == null || targetType.IsAssignableFrom(result.GetType()))
                return result;
            else
                return System.Convert.ChangeType(result, targetType);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
