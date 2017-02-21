using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oct3rdExamManagement.Startup))]
namespace Oct3rdExamManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
