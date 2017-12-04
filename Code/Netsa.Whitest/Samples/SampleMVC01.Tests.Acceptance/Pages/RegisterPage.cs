using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.UI.PageObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using SampleMVC01.Tests.Acceptance.Models;

namespace SampleMVC01.Tests.Acceptance.Pages
{
    public class RegisterPage : BasePage
    {
        protected override string RelativeUrl => "/Account/Register";

        private IWebElement EmailInput => Driver.FindElement(By.Id("Email"));
        private IWebElement PasswordInput => Driver.FindElement(By.Id("Password"));
        private IWebElement PasswordConfirmInput => Driver.FindElement(By.Id("ConfirmPassword"));
        private IWebElement SubmitButton => Driver.FindElement(By.Id("submitButton"));
        
        public void FillRegistrationForm(RegisterModel model)
        {
            EmailInput.SendKeys(model.Email);
            PasswordInput.SendKeys(model.Password);
            PasswordConfirmInput.SendKeys(model.ConfirmPassword);
        }

        public void PressSubmit()
        {
            SubmitButton.Click();
        }
    }
}
