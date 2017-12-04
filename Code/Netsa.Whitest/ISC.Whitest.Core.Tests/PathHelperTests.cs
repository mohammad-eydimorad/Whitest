using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Core.IO;
using Xunit;

namespace ISC.Whitest.Core.Tests
{
    public class PathHelperTests
    {
        [Fact]
        public void When_relative_path_is_valid_should_calculate_based_on_base_path()
        {
            var basePath = @"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE";
            var relative = @"..\..\..\Microsoft Silverlight";

            var result = PathHelper.RelativeToAbsolute(basePath, relative);
            var expected = @"C:\Program Files (x86)\Microsoft Silverlight";

            Assert.Equal(expected,result);
        }
    }
}
