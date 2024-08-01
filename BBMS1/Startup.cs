using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BBMS1.Startup))]
namespace BBMS1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
