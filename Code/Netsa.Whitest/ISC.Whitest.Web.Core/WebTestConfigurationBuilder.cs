using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.Core.IISHosting;

namespace ISC.Whitest.Web.Core
{
    public class WebTestConfigurationBuilder
    {
        private bool useIISExpress;
        private string iisExpressPath;

        public WebTestConfigurationBuilder UseIISExpress()
        {
            return UseIISExpress(IISExpressConstants.IISExpressPath);
        }
        public WebTestConfigurationBuilder UseIISExpressX86()
        {
            return UseIISExpress(IISExpressConstants.IISExpressX86Path);
        }
        private WebTestConfigurationBuilder UseIISExpress(string path)
        {
            this.useIISExpress = true;
            this.iisExpressPath = path;
            return this;
        }

        public WebTestConfiguration Build()
        {
            return new WebTestConfiguration(this.useIISExpress, this.iisExpressPath);
        }
    }
}
