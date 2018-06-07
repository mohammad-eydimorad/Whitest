using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;

namespace ISC.Whitest.Web.Core.Context
{
    public interface IScenarioContext
    {
        IObjectContainer ScenarioContainer { get; }
        void Add(string key, object model);
        void Update(string key, object model);
        T Get<T>(string key);
    }
}
