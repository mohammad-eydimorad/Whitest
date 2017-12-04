using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Core.Configuration;
using Xunit;
using Xunit.Sdk;

namespace ISC.Whitest.Core.Tests
{
    public class ConfigServiceTests
    {
        [Fact]
        public void When_value_is_not_presented_get_safe_should_return_default_value()
        {
            var value = ConfigurationService.GetValueSafe<string>("KeyThatIsNotPresented");
            Assert.Null(value);
        }

        [Fact]
        public void When_value_is_not_presented_get_should_throw_exception()
        {
            Assert.Throws<KeyNotFoundException>(() =>
            {
                var value = ConfigurationService.GetValue<string>("KeyThatIsNotPresented");
            });
        }

        [Fact]
        public void When_value_is_numeric_should_able_cast_to_numeric_types()
        {
            ConfigurationManager.AppSettings["CustomConfigurationKey"] = "120";

            var value = ConfigurationService.GetValueSafe<long>("CustomConfigurationKey");
            Assert.Equal(120,value);
        }

        [Fact]
        public void When_value_is_dateTime_should_able_cast_to_dateTime()
        {
            ConfigurationManager.AppSettings["CustomConfigurationKey"] = "2012/09/20 13:27:00";

            var value = ConfigurationService.GetValueSafe<DateTime>("CustomConfigurationKey");

            var expected = new DateTime(2012, 9,20,13,27,0);
            Assert.Equal(expected,value);
        }
    }
}
