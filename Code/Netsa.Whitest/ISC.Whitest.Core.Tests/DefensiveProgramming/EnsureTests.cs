using System.Collections.Generic;
using FluentAssertions;
using ISC.Whitest.Core.DefensiveProgramming;
using Xunit;

namespace ISC.Whitest.Core.Tests.DefensiveProgramming
{
    public class EnsureTests
    {
        [Fact]
        public void CollectionHasBeenInitialized_should_return_empty_list_when_input_list_is_null()
        {
            //Arrange
            List<long> targetList = null;

            //Act
            Ensure.That.CollectionHasBeenInitialized(ref targetList);

            //Assert
            targetList.Should().NotBeNull();
        }

        [Fact]
        public void CollectionHasBeenInitialized_should_not_change_list_when_input_list_is_not_null()
        {
            //Arrange
            var targetList = new List<long>() {10,20};

            //Act
            Ensure.That.CollectionHasBeenInitialized(ref targetList);

            //Assert
            targetList.Should().HaveCount(2)
                                .And.Contain(10)
                                .And.Contain(20);
        }

      

        [Fact]
        public void CollectionHasBeenInitialized_should_return_empty_array_when_input_array_is_null()
        {
            long[] targetList = null;
            Ensure.That.CollectionHasBeenInitialized(ref targetList);
            targetList.Should().NotBeNull();
        }

        [Fact]
        public void CollectionHasBeenInitialized_should_not_change_array_when_input_array_is_not_null()
        {
            //Arrange
            var targetList = new long[] { 10, 20 };

            //Act
            Ensure.That.CollectionHasBeenInitialized(ref targetList);

            //Assert
            targetList.Should().HaveCount(2)
                .And.Contain(10)
                .And.Contain(20);
        }
    }
}
