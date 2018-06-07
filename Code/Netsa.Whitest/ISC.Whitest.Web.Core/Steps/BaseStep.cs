using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.Core.Context;
using Mapster;
using TechTalk.SpecFlow;

namespace ISC.Whitest.Web.Core.Steps
{
    public abstract class BaseStep
    {
        protected readonly IScenarioContext CurrentScenarioContext;
        protected BaseStep(ScenarioContext currentScenarioContext)
        {
            CurrentScenarioContext = new SpecflowScenarioContextAdapter(currentScenarioContext);
        }
    }
}
