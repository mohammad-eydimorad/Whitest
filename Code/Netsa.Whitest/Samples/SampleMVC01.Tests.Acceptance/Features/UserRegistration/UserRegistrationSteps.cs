using System;
using System.Runtime.Remoting.Contexts;
using ISC.Whitest.Core.Configuration;
using ISC.Whitest.Core.IO;
using ISC.Whitest.Web.Core;
using ISC.Whitest.Web.Core.SpecflowExtentions;
using ISC.Whitest.Web.Core.ValueTransformation;
using ISC.Whitest.Web.UI.Configuration;
using ISC.Whitest.Web.UI.PageObjectModel;
using SampleMVC01.Tests.Acceptance.Models;
using SampleMVC01.Tests.Acceptance.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace SampleMVC01.Tests.Acceptance.Features.UserRegistration
{
    [Binding]
    public class UserRegistrationSteps
    {
        private readonly ScenarioContext _context;
        private readonly RegisterPage _registerPage;
        private readonly ManagePage _managePage;
        public UserRegistrationSteps(PageFactory pageFactory, ScenarioContext context)
        {
            _context = context;
            _registerPage = pageFactory.Create<RegisterPage>();
            _managePage = pageFactory.Create<ManagePage>();
        }

        [Given(@"I want to register with the following details :")]
        public void GivenIWantToRegisterWithTheFollowingDetails(Table table)
        {
            var registerModel = table.CreateInstance<RegisterModel>(_context);

            _registerPage.Open();
            _registerPage.FillRegistrationForm(registerModel);
        }
        
        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {
            _registerPage.PressSubmit();
        }
        
        [Then(@"I should be given access to the site")]
        public void ThenIShouldBeGivenAccessToTheSite()
        {
            _managePage.Open();
            Assert.True(_managePage.IsOpen());
        }
    }
}
