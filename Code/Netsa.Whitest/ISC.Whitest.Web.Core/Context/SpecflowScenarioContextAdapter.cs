using System.Collections.Generic;
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
            _scenarioContext.Add(key, model);
        }
        public void Update(string key, object model)
        {
            _scenarioContext[key] = model;
        }
        public T Get<T>(string key)
        {
            GuardAgainstInvalidKey<T>(key);
            return GetItemFromScenarioContext<T>(key);
        }
        private void GuardAgainstInvalidKey<T>(string key)
        {
            if (!_scenarioContext.ContainsKey(key))
                throw new KeyNotFoundException();
        }

        private T GetItemFromScenarioContext<T>(string key)
        {
            var item = _scenarioContext[key];
            return AdaptTypeToDesirableType<T>(item);
        }
        private T AdaptTypeToDesirableType<T>(object item)
        {
            if (item.GetType() == typeof(T)) return (T)item;
            return item.Adapt<T>();
        }
    }
}