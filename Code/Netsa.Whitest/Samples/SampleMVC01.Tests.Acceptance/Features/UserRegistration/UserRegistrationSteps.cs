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
        private readonly RegisterPage _registerPage;
        private readonly ManagePage _managePage;
        public UserRegistrationSteps(ScenarioContext context)
        {
            _registerPage = PageFactory.Create<RegisterPage>(context);
            _managePage = PageFactory.Create<ManagePage>(context);
        }

        [Given(@"I want to register with the following details :")]
        public void GivenIWantToRegisterWithTheFollowingDetails(Table table)
        {
            var registerModel = table.CreateInstance<RegisterModel>();

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
