using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Concert_Tickets.Startup))]
namespace Concert_Tickets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
