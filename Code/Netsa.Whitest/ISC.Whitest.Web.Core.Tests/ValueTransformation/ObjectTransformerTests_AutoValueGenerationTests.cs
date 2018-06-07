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
    public class ObjectTransformerTests_AutoValueGenerationTests
    {
        #region HelperClasses
        private class Customer
        {
            [TransformValue]
            public string Username { get; set; }

            [TransformValue]
            public long RefferalId { get; set; }

            [TransformValue]
            public int DepartmentId { get; set; }

            [TransformValue]
            public Guid LocationId { get; set; }
        } 
        #endregion

        private FakeScenarioContext fakeContext;
        private TransformValueManager valueManager;
        public ObjectTransformerTests_AutoValueGenerationTests()
        {
            valueManager = new TransformValueManager();
            fakeContext = new FakeScenarioContextBuilder()
                .RegisterService(valueManager)
                .Build();
        }
        
        [Fact]
        public void Transform_should_transform_properties_based_on_their_type_when_FieldType_is_set_to_auto()
        {
            //Arrange
            const string admin = "ADMIN";
            const long referralId = 10;
            const int departmentId = 5;
            var locationId = Guid.NewGuid();
            var customer = new Customer()
            {
                Username = admin,
                RefferalId = referralId,
                DepartmentId = departmentId,
                LocationId = locationId
            };

            //Act
            ObjectTransformer.Transform(customer,this.fakeContext);

            //Assert
            customer.Username.Should().NotBe(admin, "because 'string' properties should change automatically");
            customer.RefferalId.Should().NotBe(referralId, "because 'long' properties should change automatically");
            customer.DepartmentId.Should().NotBe(departmentId, "because 'int' properties should change automatically");
            customer.LocationId.Should().NotBe(locationId, "because 'Guid' properties should change automatically");
        }
    }
}
