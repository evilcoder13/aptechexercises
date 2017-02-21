using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oct5thMVCProjectManagement.Startup))]
namespace Oct5thMVCProjectManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
