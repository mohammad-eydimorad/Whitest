using FluentAssertions;
using ISC.Whitest.Core.IO;
using Xunit;

namespace ISC.Whitest.Core.Tests.IO
{
    public class PathHelperTests
    {
        [Fact]
        public void RelativeToAbsolute_should_calculate_based_on_base_path()
        {
            //Arrange
            const string basePath = @"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE";
            const string relative = @"..\..\..\Microsoft Silverlight";
            const string expectedPath = @"C:\Program Files (x86)\Microsoft Silverlight";

            //Act
            var actualPath = PathHelper.RelativeToAbsolute(basePath, relative);

            //Assert
            actualPath.Should().Be(expectedPath);
        }
    }
}
