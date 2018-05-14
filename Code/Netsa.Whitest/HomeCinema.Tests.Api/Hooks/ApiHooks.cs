using TechTalk.SpecFlow;

namespace HomeCinema.Tests.Api.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly ScenarioContext _context;
        public ScenarioHooks(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario("Api")]
        public void InitializeUser()
        {
            _context.Add("Administrator", new ApiUser());
        }
    }
}