using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Web.UI.CssSelectors
{
    public static class CssSelector
    {
        public static string ById(string elementId)
        {
            return $"#{elementId}";
        }

        public static string ByName(string elementName)
        {
            return $"[name='{elementName}']";
        }
    }
}
