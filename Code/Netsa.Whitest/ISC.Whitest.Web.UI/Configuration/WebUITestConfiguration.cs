using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ISC.Whitest.Web.UI.Configuration
{
    internal static class WebUITestConfiguration
    {
        internal static Func<IWebDriver> DriverFactory;
        internal static string BaseUrl;
    }
}
