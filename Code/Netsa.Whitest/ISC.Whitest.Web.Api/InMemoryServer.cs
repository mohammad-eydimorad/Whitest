using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ISC.Whitest.Web.Api
{
    public class InMemoryServer : HttpMessageHandler
    {
        private readonly HttpMessageInvoker _invoker;
        public InMemoryServer(HttpConfiguration configuration)
        {
            var httpServer = new HttpServer(configuration);
            _invoker = new HttpMessageInvoker(httpServer);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _invoker.SendAsync(request, cancellationToken);
        }
    }
}
