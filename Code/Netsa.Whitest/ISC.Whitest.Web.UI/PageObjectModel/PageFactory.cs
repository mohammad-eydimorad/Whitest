using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.UI.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ISC.Whitest.Web.UI.PageObjectModel
{
    public class PageFactory : IPageFactory
    {
        private readonly IWebDriver _driver;
        public PageFactory()
        {
            _driver = WebUITestConfiguration.DriverFactory();
        }
        public T Create<T>() where T : BasePage<T>, new()
        {
            var page = new T();
            page.Initial(_driver, WebUITestConfiguration.BaseUrl);
            return page;
        }
        public void Dispose()
        {
            _driver.Close();
        }
    }
}
