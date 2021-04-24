using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreFrontVersion1.Startup))]
namespace StoreFrontVersion1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
