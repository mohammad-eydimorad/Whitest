using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ISC.Whitest.Web.Core.Tests.TestUtil;
using ISC.Whitest.Web.Core.ValueTransformation;
using NSubstitute;
using Xunit;

namespace ISC.Whitest.Web.Core.Tests.ValueTransformation
{
    public class ObjectTransformerTests_KeyTests
    {
        #region HelperClasses
        private class Customer
        {
            [TransformValue(FieldType.Username)]
            public string Username { get; set; }
        } 
        #endregion

        private FakeScenarioContext fakeContext;
        private TransformValueManager valueManager;
        public ObjectTransformerTests_KeyTests()
        {
            valueManager = new TransformValueManager();
            fakeContext = new FakeScenarioContextBuilder()
                .RegisterService(valueManager)
                .Build();
        }
        
        [Fact]
        public void Transform_should_transform_object_using_specified_key_when_key_is_passed_in()
        {
            //Arrange
            const string key = "NEWCUSTOMER";
            const string admin = "ADMIN";
            var model = new Customer() { Username = admin};
            var expectedGeneratedKey = ObjectTransformer.GeneratePropertyKey(key, nameof(Customer.Username));

            //Act
            ObjectTransformer.Transform(model, key, fakeContext);

            //Assert
            model.Username.Should().NotBe(admin).And.Should().NotBeNull();
            var property = valueManager.GetTransformedProperties().First(a => a.Key == expectedGeneratedKey);
            property.OriginalValue.Should().Be(admin);
            property.TransformedValue.Should().Be(model.Username);
        }

        [Fact]
        public void Transform_should_transform_property_using_auto_generated_key_when_key_is_not_defined()
        {
            //Arrange
            const string admin = "ADMIN";
            var model = new Customer() { Username = admin };
            var expectedGeneratedKey = ObjectTransformer.GeneratePropertyKey(nameof(Customer), nameof(Customer.Username));

            //Act
            ObjectTransformer.Transform(model, fakeContext);

            //Assert
            model.Username.Should().NotBe(admin).And.Should().NotBeNull();
            var property = valueManager.GetTransformedProperties().First(a => a.Key == expectedGeneratedKey);
            property.OriginalValue.Should().Be(admin);
            property.TransformedValue.Should().Be(model.Username);
        }
    }
}
