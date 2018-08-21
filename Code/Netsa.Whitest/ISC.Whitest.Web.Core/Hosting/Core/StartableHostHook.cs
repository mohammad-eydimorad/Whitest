using System.Threading;
using ISC.Whitest.Web.Core.Hooks;

namespace ISC.Whitest.Web.Core.Hosting.Core
{
    public class StartableHostHook : IWebConfiguratonHook
    {
        private readonly IStartableHost _host;
        public StartableHostHook(IStartableHost host)
        {
            _host = host;
        }
        public void Start()
        {
            _host.Start();
            WaitForHostCompleted();
        }

        private void WaitForHostCompleted()
        {
            Thread.Sleep(500);
        }

        public void Stop()
        {
            _host.Stop();
        }
    }
}
