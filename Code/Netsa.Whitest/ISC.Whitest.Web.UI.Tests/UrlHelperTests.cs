using System;
using Xunit;
using Xunit.Sdk;

namespace ISC.Whitest.Web.UI.Tests
{
    public class UrlHelperTests
    {
        [Theory]
        [InlineData("http://localhost:5050/Manage", "http://localhost:5050/Manage")]
        [InlineData("http://localhost:5050/Manage#part1", "http://localhost:5050/Manage")]
        [InlineData("http://localhost:5050/Manage#part1&part2", "http://localhost:5050/Manage")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void When_url_has_fragments_should_remove_fragments(string target, string expected)
        {
            var result = UrlHelper.WithoutFragments(target);
            Assert.Equal(expected,result);
        }
    }
}
