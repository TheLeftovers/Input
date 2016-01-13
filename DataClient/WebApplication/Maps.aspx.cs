using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Maps : System.Web.UI.Page
    {
        public object[] LatLonArrayList;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetterService.GetterClient proxy = new GetterService.GetterClient();

            proxy.Open();
            LatLonArrayList = proxy.GetLatLon();

            proxy.Close();
            Serialize(LatLonArrayList);

        }

        public static string Serialize(object o)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(o);
        }
    }
}