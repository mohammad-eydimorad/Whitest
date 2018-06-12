using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ISC.Whitest.Web.UI.Extentions
{
    public static class WebElementExtentions
    {
        public static void ClearAndSendKeys(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public static string GetValue(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static T GetValue<T>(this IWebElement element)
        {
            var value = element.GetValue();
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
