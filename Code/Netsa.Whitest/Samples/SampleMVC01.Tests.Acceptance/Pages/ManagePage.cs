using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.UI.PageObjectModel;
using OpenQA.Selenium;

namespace SampleMVC01.Tests.Acceptance.Pages
{
    public class ManagePage : BasePage
    {
        protected override string RelativeUrl => "/Manage";

        public IWebElement UsernameText => Driver.FindElement(By.Id("greetings_username"));
    }
}
