using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleMVC01.Startup))]
namespace SampleMVC01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
