using System;
using System.Collections;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication.GetterService;

namespace WebApplication
{
    public class Global : HttpApplication
    {
        

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}