using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oct28thEAP.Startup))]
namespace Oct28thEAP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
