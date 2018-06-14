using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocalOnlyAccessTest.Startup))]
namespace LocalOnlyAccessTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
