using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HenrysBookstore.Startup))]
namespace HenrysBookstore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
