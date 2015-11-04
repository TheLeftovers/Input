using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataClient.Startup))]
namespace DataClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
