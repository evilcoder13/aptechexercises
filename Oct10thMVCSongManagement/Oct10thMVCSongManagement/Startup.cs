using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oct10thMVCSongManagement.Startup))]
namespace Oct10thMVCSongManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
