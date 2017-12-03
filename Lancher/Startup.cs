using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lancher.Startup))]
namespace Lancher
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


    }
}
