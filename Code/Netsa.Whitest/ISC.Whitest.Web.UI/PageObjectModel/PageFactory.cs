using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ISC.Whitest.Web.UI.PageObjectModel
{
    public static class PageFactory
    {
        internal static IWebDriver WebDriver;
        internal static string BaseUrl;
        public static T Create<T>() where T : BasePage, new()
        {
            var page = new T();
            page.Initial(WebDriver, BaseUrl);
            return page;
        }
    }
}
