using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSite2UploadTest.Startup))]
namespace WebSite2UploadTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
