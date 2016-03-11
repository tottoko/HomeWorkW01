using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeWorkW01.Startup))]
namespace HomeWorkW01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
