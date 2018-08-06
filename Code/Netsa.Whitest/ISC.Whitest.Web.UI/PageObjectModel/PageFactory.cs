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
        public IWebDriver Driver { get; }
        public PageFactory()
        {
            Driver = WebUITestConfiguration.DriverFactory();
        }
        public T Create<T>() where T : BasePage<T>, new()
        {
            var page = new T();
            page.Initial(Driver, WebUITestConfiguration.BaseUrl);
            return page;
        }
        public void Dispose()
        {
            Driver.Close();
        }
    }
}
