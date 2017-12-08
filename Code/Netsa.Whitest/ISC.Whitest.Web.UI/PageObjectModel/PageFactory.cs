using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ISC.Whitest.Web.UI.PageObjectModel
{
    public static class PageFactory
    {
        internal static Func<IWebDriver> driverFactory;
        internal static string BaseUrl;
        public static T Create<T>(ScenarioContext context) where T : BasePage, new()
        {
            if (!context.ContainsKey(TestContextKeys.WebDriver))
            {
                context.Add(TestContextKeys.WebDriver, driverFactory());
            }

            var driver = context.Get<IWebDriver>(TestContextKeys.WebDriver);
            var page = new T();
            page.Initial(driver, BaseUrl);
            return page;
        }
    }
}
