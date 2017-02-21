using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oct17thMVCSchoolManagement.Startup))]
namespace Oct17thMVCSchoolManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
