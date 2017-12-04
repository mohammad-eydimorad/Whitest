using OpenQA.Selenium;

namespace ISC.Whitest.Web.UI.PageObjectModel
{
    public abstract class BasePage
    {
        public IWebDriver Driver { get; private set; }
        protected string BaseUrl;
        internal void Initial(IWebDriver driver, string baseUrl)
        {
            this.Driver = driver;
            this.BaseUrl = baseUrl;
        }
        protected abstract string RelativeUrl { get; }
        protected string FullUrl => BaseUrl + RelativeUrl;

        public void Open()
        {
            Driver.Navigate().GoToUrl(FullUrl);
        }
    }
}
