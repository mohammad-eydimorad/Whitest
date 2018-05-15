using System;
using System.Collections.Generic;
using FluentAssertions;
using ISC.Whitest.Core.DefensiveProgramming;
using Xunit;

namespace ISC.Whitest.Core.Tests.DefensiveProgramming
{
    public class GuardTests
    {
        public static IEnumerable<object[]> GetNullAndEmptyCollections()
        {
            return new List<object[]>()
            {
                new Object[]{ new List<long>() },
                new Object[]{ null },
            };
        }

        [Theory]
        [MemberData(nameof(GetNullAndEmptyCollections))]
        public void NullOrEmptyEnumerable_should_throw_exception_when_enumerable_is_null_or_empty(List<long> targetList)
        {
            //Arrange
            var parameterName = nameof(targetList);

            //Act
            Action action = ()=> Guard.Against.NullOrEmptyEnumerable(targetList, parameterName);

            //Assert
            action.Should().Throw<ArgumentException>().And.ParamName.Should().Be(parameterName);
        }

        [Fact]
        public void NullOrEmptyEnumerable_should_not_throw_when_enumerable_has_values()
        {
            //Arrange
            var targetList = new List<long>() {10,20};

            //Act
            Action action = ()=> Guard.Against.NullOrEmptyEnumerable(targetList);
            
            //Assert
            action.Should().NotThrow();
        }


        [Fact]
        public void NullArgument_should_throw_when_argument_is_null()
        {
            //Arrange
            object target = null;
            var parameterName = nameof(target);

            //Act
            Action action = () => Guard.Against.NullArgument(target, parameterName);

            //Assert
            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be(parameterName);
        }

        [Fact]
        public void NullArgument_should_not_throw_when_argument_has_been_initialized()
        {
            //Arrange
            object target = new {};

            //Act
            Action action = () => Guard.Against.NullArgument(target);

            //Assert
            action.Should().NotThrow();
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void NullOrWhiteSpaceString_should_throw_when_argument_is_null_or_empty(string input)
        {
            //Arrange
            var parameterName = nameof(input);

            //Act
            Action action = ()=> Guard.Against.NullOrWhiteSpaceString(input, parameterName);

            //Assert
            action.Should().Throw<ArgumentException>().And.ParamName.Should().Be(parameterName);
        }

        [Fact]
        public void NullOrWhiteSpaceString_should_not_throw_when_argument_is_not_empty_string()
        {
            //Arrange
            const string input = "someinput";

            //Act
            Action action = () => Guard.Against.NullOrWhiteSpaceString(input);

            //Assert
            action.Should().NotThrow();
        }
    }
}
