using ISC.Whitest.Web.UI.PageObjectModel;
using SampleMVC01.Tests.Acceptance.Models;
using SampleMVC01.Tests.Acceptance.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SampleMVC01.Tests.Acceptance.Steps
{
    [Binding]
    public class UserRegistrationSteps
    {
        private readonly RegisterPage _registerPage;
        private readonly ManagePage _managePage;
        public UserRegistrationSteps()
        {
            _registerPage = PageFactory.Create<RegisterPage>();
            _managePage = PageFactory.Create<ManagePage>();
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
        }
    }
}
