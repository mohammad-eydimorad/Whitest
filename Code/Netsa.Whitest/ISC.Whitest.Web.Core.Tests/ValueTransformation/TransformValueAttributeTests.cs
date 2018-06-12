using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ISC.Whitest.Web.Core.ValueTransformation;
using Newtonsoft.Json;
using Xunit;

namespace ISC.Whitest.Web.Core.Tests.ValueTransformation
{
    public class TransformValueAttributeTests
    {
        [Fact]
        public void Constructor_should_construct_instance_properly()
        {
            //Arrange
            var fieldType = FieldType.Email;

            //Act
            var attribute = new TransformValueAttribute(fieldType);

            //Arrange
            attribute.FieldType.Should().Be(fieldType);
        }

        [Fact]
        public void Constructor_should_set_fieldType_to_auto_when_it_is_not_passed_in()
        {
            //Arrange
            var expectedFieldType = FieldType.Auto;

            //Act
            var attribute = new TransformValueAttribute();

            //Assert
            attribute.FieldType.Should().Be(expectedFieldType);
        }
    }
}
