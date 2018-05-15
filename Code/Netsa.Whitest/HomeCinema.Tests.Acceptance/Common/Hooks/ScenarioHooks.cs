using BoDi;
using HomeCinema.Tests.Acceptance.Api;
using HomeCinema.Tests.Acceptance.Common.Constants;
using HomeCinema.Tests.Acceptance.Web;
using ISC.Whitest.Core.Configuration;
using ISC.Whitest.Web.Core.ValueTransformation;
using ISC.Whitest.Web.UI.PageObjectModel;
using TechTalk.SpecFlow;

namespace HomeCinema.Tests.Acceptance.Common.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly IObjectContainer _objectContainer;

        public ScenarioHooks(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Initialize()
        {
            RegisterValueTransformation();
            RegisterPageFactory();
            RegisterCurrentUser();
        }

        private void RegisterPageFactory()
        {
            _objectContainer.RegisterTypeAs<PageFactory,IPageFactory>();
        }

        private void RegisterValueTransformation()
        {
            var transformationHandler = new ValueTransformationHandler();
            _objectContainer.RegisterInstanceAs(transformationHandler);
        }
        private void RegisterCurrentUser()
        {
            var runMode = ConfigurationService.GetValue<string>(ConfigurationConstants.RunMode);
            if (runMode == ConfigurationConstants.RunModes.Api)
            {
                _objectContainer.RegisterTypeAs<ApiAdministrator,IAdministrator>();
            }
            else
            {
                _objectContainer.RegisterTypeAs<WebAdministrator, IAdministrator>();
            }
        }
    }
}