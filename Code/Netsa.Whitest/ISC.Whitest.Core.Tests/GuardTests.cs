using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Core.DefensiveProgramming;
using Xunit;

namespace ISC.Whitest.Core.Tests
{
    public class GuardTests
    {
        [Fact]
        public void when_enumerable_is_null_should_throw_exception()
        {
            List<long> targetList = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Guard.Against.NullOrEmptyEnumerable(targetList);
            });
        }

        [Fact]
        public void when_enumerable_is_empty_should_throw_exception()
        {
            List<long> targetList = new List<long>();
            Assert.Throws<ArgumentException>(() =>
            {
                Guard.Against.NullOrEmptyEnumerable(targetList);
            });
        }

        [Fact]
        public void When_object_is_null_should_throw_exception()
        {
            object target = null;
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                Guard.Against.NullArgument(target, nameof(target));
            });
            Assert.Equal(nameof(target), exception.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void When_string_is_null_or_empty_should_throw_exception(string input)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Guard.Against.NullOrWhiteSpaceString(input);
            });
        }
    }
}
