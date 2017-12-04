using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Core.IO
{
    public class PathHelper
    {
        public static string RelativeToAbsolute(string basePath, string relativePath)
        {
            var path = Path.Combine(basePath, relativePath);
            return Path.GetFullPath(path);
        }
    }
}
