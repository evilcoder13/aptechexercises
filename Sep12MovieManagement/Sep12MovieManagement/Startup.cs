using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sep12MovieManagement.Startup))]
namespace Sep12MovieManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
