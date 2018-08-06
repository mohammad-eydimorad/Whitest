using System;
using OpenQA.Selenium;

namespace ISC.Whitest.Web.UI.PageObjectModel
{
    public interface IPageFactory : IDisposable
    {
        IWebDriver Driver { get; }
        T Create<T>() where T : BasePage<T>, new();
    }
}