using System.Collections.Generic;
using System.Linq;
using ISC.Whitest.Core.DefensiveProgramming;
using ISC.Whitest.Web.Core.Hooks;
using ISC.Whitest.Web.Core.Hosting;

namespace ISC.Whitest.Web.Core
{
    public class WebTestConfiguration
    {
        private readonly List<IWebConfiguratonHook> _hooks;
        public string BaseUrl { get; private set; }
        internal WebTestConfiguration(string baseUrl)
        {
            this._hooks = new List<IWebConfiguratonHook>();
            this.BaseUrl = baseUrl;
        }

        public void AddHook(IWebConfiguratonHook hook)
        {
            _hooks.Add(hook);
        }

        public void Start()
        {
            _hooks.ForEach(a=> a.Start());
        }

        public void Stop()
        {
            _hooks.ForEach(a=>a.Stop());
        }
    }
}