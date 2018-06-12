using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ISC.Whitest.Web.UI
{
    public static class WebDriverCustomWaits
    {
        public static void WaitUnitElementAppear(this IWebDriver driver, By selector)
        {
            driver.WaitUntil(ExpectedConditions.ElementIsVisible(selector));
        }

        public static void WaitUtillementDisappear(this IWebDriver driver, By selector)
        {
            driver.WaitUntil(ExpectedConditions.InvisibilityOfElementLocated(selector));
        }
        public static void WaitUntilElementToBeClickable(this IWebDriver driver, By selector)
        {
            driver.WaitUntil(ExpectedConditions.ElementToBeClickable(selector));
        }

        private static void WaitUntil<TResult>(this IWebDriver driver, Func<IWebDriver, TResult> condition)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
            wait.Until(condition);
        }
    }
}
