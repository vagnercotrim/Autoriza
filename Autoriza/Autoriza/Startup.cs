using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autoriza.Startup))]
namespace Autoriza
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
