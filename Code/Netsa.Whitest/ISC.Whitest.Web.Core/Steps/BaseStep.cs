using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ISC.Whitest.Web.Core.Steps
{
    public abstract class BaseStep
    {
        protected ScenarioContext Context;
        protected BaseStep(ScenarioContext context)
        {
            Context = context;
        }

        public void AddModeltoContext(string key, object model)
        {
            Context.Add(key, model);
        }
    }
}
