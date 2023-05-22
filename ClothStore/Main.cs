using ClothStore.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace ClothStore
{
    public class BoolToStringConverter : BoolToValueConverter<String> { }
    public class BoolToBrushConverter : BoolToValueConverter<Brush> { }
    public class BoolToVisibilityConverter : BoolToValueConverter<Visibility> { }
    public class BoolToObjectConverter : BoolToValueConverter<Object> { }

}
