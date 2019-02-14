using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamP.Startup))]
namespace TeamP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
