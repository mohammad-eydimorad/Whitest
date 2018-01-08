using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.Core.Hooks;
using ISC.Whitest.Web.Core.Hosting;
using ISC.Whitest.Web.Core.Hosting.Core;
using ISC.Whitest.Web.Core.Hosting.IISExpressHosting;

namespace ISC.Whitest.Web.Core
{
    public class WebTestConfigurationBuilder
    {
        private readonly List<IWebConfiguratonHook> _hooks;
        private string baseUrl;
        public WebTestConfigurationBuilder()
        {
            this._hooks = new List<IWebConfiguratonHook>();
        }
        public WebTestConfigurationBuilder UseIISExpress(string folderPath, int port)
        {
            return UseIISExpress(IISExpressConstants.IISExpressPath, folderPath, port);
        }
        public WebTestConfigurationBuilder UseIISExpressX86(string folderPath, int port)
        {
            return UseIISExpress(IISExpressConstants.IISExpressX86Path, folderPath, port);
        }
        private WebTestConfigurationBuilder UseIISExpress(string iisPath,  string folderPath, int port)
        {
            var host = new IISExpressHost(folderPath, port, iisPath);
            _hooks.Add(new StartableHostHook(host));
            baseUrl = host.Address;
            return this;
        }

        public WebTestConfigurationBuilder UseRemoteHost(string address)
        {
            this.baseUrl = address;
            return this;
        }

        public WebTestConfiguration Build()
        {
            var output = new WebTestConfiguration(baseUrl);
            _hooks.ForEach(a=> output.AddHook(a));
            return output;
        }
    }
}
