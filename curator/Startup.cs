using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(curator.Startup))]
namespace curator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
