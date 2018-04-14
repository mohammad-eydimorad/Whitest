using System;
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

        public virtual void Open()
        {
            Driver.Navigate().GoToUrl(FullUrl);
        }

        public virtual bool IsOpen(bool excludeFragments = false)
        {
            var currentDriverUrl = Driver.Url;
            var pageUrl = this.FullUrl;

            if (excludeFragments)
            {
                currentDriverUrl = UrlHelper.WithoutFragments(Driver.Url);
                pageUrl = UrlHelper.WithoutFragments(this.FullUrl);
            }
            return currentDriverUrl.Equals(pageUrl, StringComparison.OrdinalIgnoreCase);
        }
    }
}
