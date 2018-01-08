using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.Core.Hooks;

namespace ISC.Whitest.Web.Core.Hosting
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
        }

        public void Stop()
        {
            _host.Stop();
        }
    }
}
