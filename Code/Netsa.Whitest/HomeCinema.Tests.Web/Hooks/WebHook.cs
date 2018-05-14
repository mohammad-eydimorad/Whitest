using TechTalk.SpecFlow;

namespace HomeCinema.Tests.Web.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly ScenarioContext _context;
        public ScenarioHooks(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario("UI")]
        public void InitializeUser()
        {
            _context.Add("Administrator", new WebUser());
        }
    }
}