using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeCinema.Tests.Acceptance.Common.Models;
using ISC.Whitest.Web.UI.PageObjectModel;
using OpenQA.Selenium;

namespace HomeCinema.Tests.Acceptance.Web.Registration
{
    public class RegistrationPage : BasePage<RegistrationPage>
    {
        protected override string RelativeUrl => "#/register";

        private IWebElement UsernameInput => Driver.FindElement(By.Name("inputUsername"));
        private IWebElement PasswordInput => Driver.FindElement(By.Name("inputPassword"));
        private IWebElement EmailInput => Driver.FindElement(By.Name("inputEmail"));
        private IWebElement SubmitButton => Driver.FindElement(By.XPath("//button[@type='submit']"));

        public void FillRegistrationForm(RegistrationModel model)
        {
            UsernameInput.SendKeys(model.Email);
            EmailInput.SendKeys(model.Email);
            PasswordInput.SendKeys(model.Password);
            SubmitButton.Click();
        }
    }
}
