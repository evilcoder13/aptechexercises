using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oct26thEAP.Startup))]
namespace Oct26thEAP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
