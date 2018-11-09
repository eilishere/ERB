using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResumeBank.Web.Startup))]
namespace ResumeBank.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
