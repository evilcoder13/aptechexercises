using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oct12thMVCCMS.Startup))]
namespace Oct12thMVCCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
