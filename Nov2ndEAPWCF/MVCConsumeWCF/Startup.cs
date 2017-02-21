using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCConsumeWCF.Startup))]
namespace MVCConsumeWCF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
