using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fliek.Startup))]
namespace Fliek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
