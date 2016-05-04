using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CNCDataManager.Startup))]
namespace CNCDataManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
