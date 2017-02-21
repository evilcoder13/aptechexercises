using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebChatWCF.Startup))]
namespace WebChatWCF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
