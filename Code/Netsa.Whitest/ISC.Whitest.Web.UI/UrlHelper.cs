using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Web.UI
{
    public static class UrlHelper
    {
        public static string WithoutFragments(string url)
        {
            if (string.IsNullOrEmpty(url)) return url;
            var indexOfSharp = url.IndexOf("#", StringComparison.Ordinal);
            if (indexOfSharp == -1) return url;
            return url.Substring(0, indexOfSharp);
        }
    }
}
