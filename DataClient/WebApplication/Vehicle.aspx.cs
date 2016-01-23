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

        public object[] HDOPArrayList;
        public object[] SatelliteArrayList;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Create proxy
            GetterClient proxy = new GetterClient();

            proxy.Open();

            //Fill array with database rows from WCF
            UnitArrayList = proxy.GetUnitListForTopSpeed();
            SpeedArrayList = proxy.GetSpeedListForTopSpeed();

            HDOPArrayList = proxy.GetHDOPListForQuality();
            SatelliteArrayList = proxy.GetNumSatellitesListForQuality();

            proxy.Close();

            //Serialize arraylists so they can be used in JavaScript
            Serialize(UnitArrayList);
            Serialize(SpeedArrayList);
            Serialize(HDOPArrayList);
            Serialize(SatelliteArrayList);



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