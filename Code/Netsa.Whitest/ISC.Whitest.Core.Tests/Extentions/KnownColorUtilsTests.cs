using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ISC.Whitest.Core.Extentions;
using Xunit;

namespace ISC.Whitest.Core.Tests.Extentions
{
    public class KnownColorUtilsTests
    {
        [Fact]
        public void ToHexColor_should_return_hex_code_of_known_colors()
        {
            //Arrange
            var color = KnownColor.AliceBlue;
            var expectedHexCode = "#F0F8FF";

            //Act
            var actualHexCode = KnownColorUtils.ToHexColor(color);

            //Assert
            actualHexCode.Should().Be(expectedHexCode);
        }

        [Fact]
        public void FromHexColor_should_create_known_color_from_hexadecimal_code()
        {
            //Arrange
            var hexCode = "#F0F8FF";
            var expectedColor = KnownColor.AliceBlue;

            //Arrange
            var actualColor = KnownColorUtils.FromHexCode(hexCode);

            //Assert
            actualColor.Should().Be(expectedColor);
        }
    }
}
