using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Common;
using ISC.Whitest.Core.Extentions;
using Xunit;

namespace ISC.Whitest.Core.Tests.Extentions
{
    public class DictionaryExtentionsTests
    {
        //Arrange
        const string Key = "KEY";
        const string Value = "VALUE";
        const string UpdateValue = "VALUE_X";
        readonly Dictionary<string, string> _dictionary;
        public DictionaryExtentionsTests()
        {
            _dictionary = new Dictionary<string, string>();   
        }

        [Fact]
        public void AddOrUpdate_should_add_item_to_dictionary_when_key_has_not_been_added_before()
        {
            //Act
            _dictionary.AddOrUpdate(Key,Value);

            //Assert
            _dictionary.Should().HaveCount(1).And.ContainKey(Key).WhichValue.IsSameOrEqualTo(Value);
        }

        [Fact]
        public void AddOrUpdate_should_update_item_in_dictionary_when_key_has_been_added_before()
        {
            //Arrange
            _dictionary.Add(Key, Value);

            //Act
            _dictionary.AddOrUpdate(Key,UpdateValue);

            //Assert
            _dictionary.Should().HaveCount(1).And.ContainKey(Key).WhichValue.IsSameOrEqualTo(Value);
        }
    }
}
