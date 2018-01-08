using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Core.DefensiveProgramming;
using Xunit;

namespace ISC.Whitest.Core.Tests
{
    public class EnsureTests
    {
        [Fact]
        public void When_list_is_null_should_initial_it()
        {
            List<long> targetList = null;
            Ensure.That.CollectionHasBeenInitialized(ref targetList);
            Assert.NotNull(targetList);
        }

        [Fact]
        public void When_array_is_null_should_initial_it()
        {
            long[] targetList = null;
            Ensure.That.CollectionHasBeenInitialized(ref targetList);
            Assert.NotNull(targetList);
        }
    }
}
