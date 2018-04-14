using System;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Http;
using ISC.Whitest.Web.Api;
using SampleWebAPI01.Tests.Integration.Fixtures;
using Xunit;

namespace SampleWebAPI01.Tests.Integration
{
    public class CustomersApiTests : IAssemblyFixture<WebApiServerFixture>
    {
        private WebApiServerFixture _fixture;
        public CustomersApiTests(WebApiServerFixture fixture)
        {
            this._fixture = fixture;
        }

        [Fact(Skip = "Ignore")]
        public void Post_should_create_new_customer()
        {
            //var task = fixture.Client.PostAsync("http://isc.net/api/Customers", new StringContent(""));
            //task.Wait();
        }
    }
}
