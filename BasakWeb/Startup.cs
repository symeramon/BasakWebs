using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BasakWeb.Startup))]
namespace BasakWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
