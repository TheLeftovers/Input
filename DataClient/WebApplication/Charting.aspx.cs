using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Charting : System.Web.UI.Page
    {
        public object[] UnitArrayList;
        public object[] SpeedArrayList;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetterService.GetterClient proxy = new GetterService.GetterClient();

            proxy.Open();
            UnitArrayList = proxy.GetUnitList();
            SpeedArrayList = proxy.GetSpeedList();

            proxy.Close();
            Serialize(UnitArrayList);
            Serialize(SpeedArrayList);

        }

        public static string Serialize(object o)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(o);
        }
    }
}