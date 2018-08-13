using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.Core.Context;
using Mapster;
using TechTalk.SpecFlow;

namespace ISC.Whitest.Web.Core.Steps
{
    public abstract class BaseStep : TechTalk.SpecFlow.Steps
    {
        protected readonly IScenarioContext CurrentScenarioContext;
        protected BaseStep(ScenarioContext currentScenarioContext)
        {
            CurrentScenarioContext = new SpecflowScenarioContextAdapter(currentScenarioContext);
        }

        public void CallGiven<T>(string methodName)
        {
            var type = typeof(T);
            var method = type.GetMethods().First(a => a.Name.Equals(methodName));

            var givenAttribute = method.GetCustomAttributes<GivenAttribute>().First();
            var attributeText = givenAttribute.Regex;
            Given(attributeText);
        }
    }
}
