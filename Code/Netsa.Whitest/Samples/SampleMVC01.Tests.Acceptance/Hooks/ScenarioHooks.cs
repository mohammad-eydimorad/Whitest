using BoDi;
using ISC.Whitest.Web.Core.ValueTransformation;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace SampleMVC01.Tests.Acceptance.Hooks
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