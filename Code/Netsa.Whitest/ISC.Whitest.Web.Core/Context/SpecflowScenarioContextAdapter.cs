using System.Dynamic;
using BoDi;
using Mapster;
using TechTalk.SpecFlow;

namespace ISC.Whitest.Web.Core.Context
{
    public class SpecflowScenarioContextAdapter : IScenarioContext
    {
        private readonly ScenarioContext _scenarioContext;
        public IObjectContainer ScenarioContainer => _scenarioContext.ScenarioContainer;
        public SpecflowScenarioContextAdapter(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public void Add(string key, object model)
        {
            var expandoModel = model.Adapt<ExpandoObject>();
            _scenarioContext.Add(key, expandoModel);
        }
        public void Update(string key, object model)
        {
            var expandoModel = model.Adapt<ExpandoObject>();
            _scenarioContext[key] = expandoModel;
        }
        public T Get<T>(string key)
        {
            return _scenarioContext[key].Adapt<T>();
        }
    }
}