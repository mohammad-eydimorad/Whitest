using System;
using BoDi;
using ISC.Whitest.Web.Core.Context;
using NSubstitute;

namespace ISC.Whitest.Web.Core.Tests.TestUtil
{
    internal class FakeScenarioContextBuilder
    {
        private readonly IObjectContainer _objectContainer;
        public FakeScenarioContextBuilder()
        {
            this._objectContainer = NSubstitute.Substitute.For<IObjectContainer>();
        }

        public FakeScenarioContextBuilder RegisterService<T>(T instance)
        {
            this._objectContainer.IsRegistered<T>().Returns(true);
            this._objectContainer.Resolve<T>().Returns(instance);
            return this;
        }

        public FakeScenarioContextBuilder RegisterService<T>() where T : class, new()
        {
            var instance = Activator.CreateInstance<T>();
            return RegisterService(instance);
        }
         
        public FakeScenarioContext Build()
        {
            var context = new FakeScenarioContext();
            context.SetContainer(_objectContainer);
            return context;
        }
    }
}