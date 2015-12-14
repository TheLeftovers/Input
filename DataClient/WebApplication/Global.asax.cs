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

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GetPosition();

        }

        void GetPosition()
        {

            //Create proxy
            GetterClient proxy = new GetterClient();

            //Parameters getPositionsList
            int max = 10;
            string OrderBy = "Speed";

            //Open connection
            proxy.Open();

            //Place values needed in ArrayList
            for (int i = 0; i < max; i++)
            {
                unit.Add(proxy.GetPositionsList(max, OrderBy)[i].UnitId);
                speed.Add(proxy.GetPositionsList(max, OrderBy)[i].Speed);
            }

            //Close connection
            proxy.Close();
        }
    }
}