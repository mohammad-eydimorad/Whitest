using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ISC.Whitest.Web.Api;
using Xunit;

namespace SampleWebAPI01.Tests.Integration.Fixtures
{
    public class WebApiServerFixture : IDisposable
    {
        public HttpClient Client { get; private set; }
        private readonly InMemoryServer _server;
        public WebApiServerFixture()
        {
            var configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);
            _server = new InMemoryServer(configuration);

            Client = new HttpClient(_server);
        }
        public void Dispose()
        {
            _server.Dispose();
            Client.Dispose();
        }
    }
}
