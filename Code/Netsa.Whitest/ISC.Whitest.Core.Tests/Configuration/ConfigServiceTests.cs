using System;
using System.Collections.Generic;
using System.Configuration;
using FluentAssertions;
using ISC.Whitest.Core.Configuration;
using Xunit;

namespace ISC.Whitest.Core.Tests.Configuration
{
    public class ConfigServiceTests
    {
        [Fact]
        public void GetValueSafe_should_return_default_value_when_value_is_not_presented()
        {
            //Arrange
            const long expectedValue = default(long);

            //Act
            var value = ConfigurationService.GetValueSafe<long>("KeyThatIsNotPresented");
            
            //Assert
            value.Should().Be(expectedValue);
        }

        [Fact]
        public void GetValue_should_throw_when_value_is_not_presented()
        {
            //Act
            Action action = ()=> ConfigurationService.GetValue<string>("KeyThatIsNotPresented");

            //Assert
            action.Should().Throw<KeyNotFoundException>();
        }

        [Fact]
        public void GetValueSafe_should_be_able_to_cast_when_value_is_numeric()
        {
            //Arrange
            ConfigurationManager.AppSettings["CustomConfigurationKey"] = "120";
            const  long expectedValue =120;

            //Act
            var actualValue = ConfigurationService.GetValueSafe<long>("CustomConfigurationKey");

            //Assert
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void GetValueSafe_should_be_able_to_cast_when_value_is_dateTime()
        {
            //Arrange
            ConfigurationManager.AppSettings["CustomConfigurationKey"] = "2012/09/20 13:27:00";
            var expectedValue = new DateTime(2012, 9,20,13,27,0);

            //Act
            var actualValue = ConfigurationService.GetValueSafe<DateTime>("CustomConfigurationKey");

            //Assert
            actualValue.Should().Be(expectedValue);
        }
    }
}
