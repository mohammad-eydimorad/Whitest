using ISC.Whitest.Web.UI.PageObjectModel;
using SampleMVC01.Tests.Acceptance.Models;
using SampleMVC01.Tests.Acceptance.Pages;
using TechTalk.SpecFlow;
using Xunit;

namespace SampleMVC01.Tests.Acceptance.Features.UserRegistration
{
    [Binding]
    public class SecurePasswordSteps
    {
        private readonly RegisterPage _registerPage;
        public SecurePasswordSteps(ScenarioContext context)
        {
            this._registerPage = PageFactory.Create<RegisterPage>(context);
        }

        [Then(@"I should be inform that password is too short")]
        public void ThenIShouldBeInformThatPasswordIsTooShort()
        {
            var hasErrors = _registerPage.HasErrors(RegisterErrors.ShortPasswordError);
            Assert.True(hasErrors);
        }

        [Then(@"I should be inform that password should have at least one digit")]
        public void ThenIShouldBeInformThatPasswordShouldHaveAtLeastOneDigit()
        {
            var hasErrors = _registerPage.HasErrors(RegisterErrors.ShouldAtLastOneDigit);
            Assert.True(hasErrors);
        }
    }
}
