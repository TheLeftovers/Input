using System;
using System.Collections;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication.GetterService;

namespace WebApplication
{
    public class Global : HttpApplication
    {
        //New ArrayLists of data used in chart(XY) in Vehicle.aspx.cs
        public static ArrayList unit = new ArrayList();
        public static ArrayList speed = new ArrayList();
        public static ArrayList hdop = new ArrayList();
        public static ArrayList sats = new ArrayList();

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            int max = 50;

            //Create proxy
            GetterClient proxy = new GetterClient();

            //Open connection
            proxy.Open();

            //Place values needed in ArrayList
            for (int i = 0; i < max; i++)
            {
                unit.Add(proxy.GetUnitList()[i]);
                speed.Add(proxy.GetSpeedList()[i]);
                hdop.Add(proxy.GetHDOPList()[i]);
                sats.Add(proxy.GetNumSatellitesList()[i]);
            }

            //Close connection
            proxy.Close();
        }
    }
}