using HomeCinema.Tests.Acceptance.Common.Constants;
using HomeCinema.Tests.Acceptance.Common.Models;
using ISC.Whitest.Web.Core.SpecflowExtentions;
using ISC.Whitest.Web.Core.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace HomeCinema.Tests.Acceptance.Common.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
        private readonly IAdministrator _administrator;
        public LoginSteps(ScenarioContext context, IAdministrator administrator) : base(context)
        {
            this._administrator = administrator;
        }

        [Given(@"I have already registered with following information :")]
        public void GivenIHaveAlreadyRegisteredWithFollowingInformation(Table table)
        {
            var model = table.CreateInstance<RegistrationTestModel>(this.Context);
            base.AddModeltoContext(UserConstants.Registration,model);
            _administrator.Register(model);
        }
        
        [When(@"I log in")]
        public void WhenILogIn()
        {
            var model = Context.Get<RegistrationTestModel>(UserConstants.Registration);
            _administrator.Login(model.Email, model.Password);
        }
        
        [Then(@"I should be given access to the site")]
        public void ThenIShouldBeGivenAccessToTheSite()
        {
            var isLoggedIn = _administrator.IsLoggedIn();
            Assert.IsTrue(isLoggedIn);
        }
    }
}
