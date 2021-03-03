using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCProject_ArefinFardu.Startup))]
namespace MVCProject_ArefinFardu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
