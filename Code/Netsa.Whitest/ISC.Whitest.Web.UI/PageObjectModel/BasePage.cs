using System;
using OpenQA.Selenium;

namespace ISC.Whitest.Web.UI.PageObjectModel
{
    public abstract class BasePage<T> where T : BasePage<T>
    {
        public IWebDriver Driver { get; private set; }
        protected string BaseUrl;
        internal void Initial(IWebDriver driver, string baseUrl)
        {
            this.Driver = driver;
            this.BaseUrl = baseUrl;
            AfterInitialization();
        }
        protected abstract string RelativeUrl { get; }
        protected string FullUrl => BaseUrl + RelativeUrl;

        public virtual T Open()
        {
            Driver.Navigate().GoToUrl(FullUrl);
            return (T)this;
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

        public virtual void AfterInitialization() { }
    }
}
