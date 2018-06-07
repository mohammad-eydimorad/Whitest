using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ISC.Whitest.Core.Extentions;
using Xunit;

namespace ISC.Whitest.Core.Tests.Extentions
{
    public class EnumExtentionsTests
    {
        #region HelperClasses
        private const string Description = "TEST";
        private enum TestEnum
        {
            [Description(Description)]
            SomeEnumWithDescription = 0,
            SomeEnumWithoutDescription = 1,
        } 
        #endregion

        [Fact]
        public void GetDescription_should_extract_description_from_DescriptionAttribute()
        {
            //Arrange
            var value = TestEnum.SomeEnumWithDescription;

            //Act
            var extractedDescription = value.GetDescription();

            //Assert
            extractedDescription.Should().Be(Description);
        }

        [Fact]
        public void GetDescription_should_return_null_when_no_DescriptionAttribute_is_available_on_enum()
        {
            //Arrange
            var value = TestEnum.SomeEnumWithoutDescription;

            //Act
            var extractedDescription = value.GetDescription();

            //Assert
            extractedDescription.Should().Be(null);
        }
    }
}
