using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oct19thMVCEmployeeManagement.Startup))]
namespace Oct19thMVCEmployeeManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
