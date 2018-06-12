using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Core.Extentions
{
    public static class KnownColorUtils
    {
        public static string ToHexColor(this KnownColor knownColor)
        {
            var color = Color.FromKnownColor(knownColor);
            var colorHexValue = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            return colorHexValue;
        }

        public static KnownColor FromHexCode(string hexCode)
        {
            var color = (Color)new ColorConverter().ConvertFromString(hexCode);
            return color.ToKnownColor();
        }

    }
}
