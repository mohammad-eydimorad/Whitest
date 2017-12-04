using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.Core.Hosting;
using ISC.Whitest.Web.Core.IISHosting;

namespace ISC.Whitest.Web.Core
{
    public class WebTestConfigurationBuilder
    {
        private IHost host;
        public WebTestConfigurationBuilder UseIISExpress(string folderPath, int port)
        {
            return UseIISExpress(IISExpressConstants.IISExpressPath, folderPath, port);
        }
        public WebTestConfigurationBuilder UseIISExpressX86(string folderPath, int port)
        {
            return UseIISExpress(IISExpressConstants.IISExpressX86Path, folderPath, port);
        }
        private WebTestConfigurationBuilder UseIISExpress(string iisPath, 
            string folderPath, int port)
        {
            host = new IISExpressHost(folderPath, port, iisPath);
            return this;
        }

        public WebTestConfiguration Build()
        {
            return new WebTestConfiguration(host);
        }
    }
}
