using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Core.Extentions
{
    public static class StringExtentions
    {
        public static string SurroundByDoubleQoutes(this string input)
        {
            return $"\"{input}\"";
        }
    }
}
