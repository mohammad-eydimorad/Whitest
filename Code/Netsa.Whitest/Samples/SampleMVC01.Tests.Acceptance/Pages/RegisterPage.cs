using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private IWebElement ValidationSummary => Driver.FindElement(By.Id("validationSummary"));

        public void FillRegistrationForm(RegisterModel model)
        {
            EmailInput.SendKeys(model.Email);
            PasswordInput.SendKeys(model.Password);
            PasswordConfirmInput.SendKeys(model.ConfirmPassword);
        }

        public bool HasErrors(params string[] expectedErrors)
        {
            var errorList = GetAllErrors();
            if (!errorList.Any()) return false;

            var regexList = expectedErrors.Select(a => new Regex(a)).ToList();
            return regexList.All(regex => errorList.Any(regex.IsMatch));
        }

        private List<string> GetAllErrors()
        {
            var items = ValidationSummary.FindElements(By.TagName("li"));
            return items.Select(a => a.Text).ToList();
        }

        public void PressSubmit()
        {
            SubmitButton.Click();
        }
    }
}
