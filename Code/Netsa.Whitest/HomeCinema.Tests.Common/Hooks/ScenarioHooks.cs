using BoDi;
using ISC.Whitest.Web.Core.ValueTransformation;
using TechTalk.SpecFlow;

namespace HomeCinema.Tests.Common.Hooks
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
        public void InitializeWebDriver()
        {
            var transformationHandler = new ValueTransformationHandler();
            _objectContainer.RegisterInstanceAs(transformationHandler);
        }
    }
}