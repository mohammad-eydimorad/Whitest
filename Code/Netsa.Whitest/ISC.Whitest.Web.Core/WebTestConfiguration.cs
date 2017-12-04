using ISC.Whitest.Web.Core.Hosting;

namespace ISC.Whitest.Web.Core
{
    public class WebTestConfiguration
    {
        public IHost Host { get; }
        internal WebTestConfiguration(IHost host)
        {
            Host = host;
        }

        public void Start()
        {
            var startable = Host as IStartableHost;
            startable?.Start();
        }

        public void Stop()
        {
            var startable = Host as IStartableHost;
            startable?.Stop();
        }
    }
}