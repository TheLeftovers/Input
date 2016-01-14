using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using WebApplication.GetterService;

namespace WebApplication
{
    public partial class Vehicle : Page
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

            if (WebApplication.SiteMaster.LoggedIn)
            {
                AnonymousContent.Visible = false;
                AuthorizedContent.Visible = true;
            }
            else
            {
                AnonymousContent.Visible = true;
                AuthorizedContent.Visible = false;
            }
        }

        public static string Serialize(object o)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(o);
        }
    }
}