using System;
using System.Globalization;
using System.Windows.Data;

namespace ch.bbbaden.m426.Zahlenpuzzle.GUI.Wpf.Converters
{
  public class TileToStringConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (!(value is ITile) || targetType != typeof(string))
      {
        throw new NotSupportedException();
      }

      return (value as NumberTile)?.Number.ToString() ?? string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotSupportedException();
    }
  }
}