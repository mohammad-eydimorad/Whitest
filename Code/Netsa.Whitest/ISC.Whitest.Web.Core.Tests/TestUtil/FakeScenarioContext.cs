using System.Collections.Generic;
using BoDi;
using ISC.Whitest.Web.Core.Context;

namespace ISC.Whitest.Web.Core.Tests.TestUtil
{
    internal class FakeScenarioContext : IScenarioContext
    {
        private readonly Dictionary<string, object> _items = new Dictionary<string, object>();
        public IObjectContainer ScenarioContainer { get; private set; }

        public void SetContainer(IObjectContainer container)
        {
            this.ScenarioContainer = container;
        }

        public void Add(string key, object model)
        {
            this._items.Add(key, model);
        }

        public void Update(string key, object model)
        {
            this._items[key] = model;
        }

        public T Get<T>(string key)
        {
            return (T)this._items[key];
        }
    }
}
