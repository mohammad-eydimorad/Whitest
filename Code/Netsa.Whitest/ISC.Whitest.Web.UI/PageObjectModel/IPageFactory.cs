using System;

namespace ISC.Whitest.Web.UI.PageObjectModel
{
    public interface IPageFactory : IDisposable
    {
        T Create<T>() where T : BasePage<T>, new();
    }
}