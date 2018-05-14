using HomeCinema.Tests.Common.Constants;
using HomeCinema.Tests.Common.Models;
using ISC.Whitest.Web.Core.SpecflowExtentions;
using ISC.Whitest.Web.Core.Steps;
using TechTalk.SpecFlow;

namespace HomeCinema.Tests.Common.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
        private readonly IAdministrator _administrator;
        public LoginSteps(ScenarioContext context) : base(context)
        {
            this._administrator = context.Get<IAdministrator>("Administrator");
        }

        [Given(@"I have already registered with following information :")]
        public void GivenIHaveAlreadyRegisteredWithFollowingInformation(Table table)
        {
            var model = table.CreateInstance<RegistrationModel>(this.Context);
            base.AddModeltoContext(UserConstants.Registration,model);
            _administrator.Register(model);
        }
        
        [When(@"I log in")]
        public void WhenILogIn()
        {
            var model = Context.Get<RegistrationModel>(UserConstants.Registration);
            _administrator.Login(model.Email, model.Password);
        }
        
        [Then(@"I should be given access to the site")]
        public void ThenIShouldBeGivenAccessToTheSite()
        {
            var isLoggedIn = _administrator.IsLoggedIn();

        }
    }
}
