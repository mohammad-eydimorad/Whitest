using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Core.Configuration;
using ISC.Whitest.Core.IO;
using ISC.Whitest.Web.Core;
using ISC.Whitest.Web.UI.Configuration;
using TechTalk.SpecFlow;

namespace SampleMVC01.Tests.Acceptance.Hooks
{
    [Binding]
    public static class TestSuiteHooks
    {
        private static WebTestConfiguration configuration;

        [BeforeTestRun]
        public static void BeforeTests()
        {
            var webFolderPath = ConfigurationService.GetValue<string>("SUTFolderPath");
            webFolderPath = PathHelper.RelativeToAbsolute(AppDomain.CurrentDomain.BaseDirectory, webFolderPath);
            var port = ConfigurationService.GetValue<int>("Port");
            var driverPath = ConfigurationService.GetValue<string>("DriverPath");
            driverPath = PathHelper.RelativeToAbsolute(AppDomain.CurrentDomain.BaseDirectory, driverPath);

            configuration = new WebTestConfigurationBuilder()
                       .UseIISExpressX86(webFolderPath, port)
                       .Build();

            configuration.UseChrome(driverPath).Start();
            //configuration.UsePhantomJs(driverPath).Start();
        }

        [AfterTestRun]
        public static void AfterTests()
        {
            configuration.Stop();
        }

    }
}
