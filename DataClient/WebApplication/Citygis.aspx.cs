using System;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using WebApplication.GetterService;

namespace WebApplication
{
    public partial class Citygis : System.Web.UI.Page
    {
        public object[] ConnBoolTrueArrayList;
        public object[] ConnBoolFalseArrayList;
        public object[] DateArrayList;
        public object[] TempArrayList;
        public object[] CPUDateArrayList;
        public object[] CPUTempArrayList;
        public object[] UnitRepairArrayList;
        public object[] CountRepairArrayList;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebApplication.SiteMaster.LoggedIn)
            {
                //Show divs when logged in
                AnonymousContent.Visible = false;
                AuthorizedContent.Visible = true;

                GetterClient proxy = new GetterClient();

                proxy.Open();

                //Fill array with database rows from WCF
                ConnBoolTrueArrayList = proxy.GetQueryList("SELECT COUNT(value) FROM connections WHERE value = 'True'");
                ConnBoolFalseArrayList = proxy.GetQueryList("SELECT COUNT(value) FROM connections WHERE value = 'False'");
                DateArrayList = proxy.GetBeginTimeListForGPSTemp();
                TempArrayList = proxy.GetMaxListForGPSTemp();
                CPUDateArrayList = proxy.GetBeginTimeListForCPUTemp();
                CPUTempArrayList = proxy.GetMaxListForCPUTemp();
                UnitRepairArrayList = proxy.GetUnitListbyRepair();
                CountRepairArrayList = proxy.GetCountListbyRepair();

                proxy.Close();

                //Serialize arraylists so they can be used in JavaScript
                Serialize(ConnBoolTrueArrayList);
                Serialize(ConnBoolFalseArrayList);
                Serialize(DateArrayList);
                Serialize(TempArrayList);
                Serialize(CPUDateArrayList);
                Serialize(CPUTempArrayList);
                Serialize(UnitRepairArrayList);
                Serialize(CountRepairArrayList);
            }
            else
            {
                AnonymousContent.Visible = true;
                AuthorizedContent.Visible = false;
            }
        }

        //  CREATE CHART METHODS
        public void CreateChart3()
        {

            //Create proxy
            GetterClient proxy = new GetterClient();

            //Open connection
            proxy.Open();

            //Get data from database with selected dates and times
            DateArrayList = proxy.GetBeginTimeListForGPSTemp();
            TempArrayList = proxy.GetMaxListForGPSTemp();

            proxy.Close();

            //Serialize arraylists so they can be used in JavaScript
            Serialize(DateArrayList);
            Serialize(TempArrayList);
        }

        public void CreateChart4()
        {

            //Create proxy
            GetterClient proxy = new GetterClient();

            //Open connection
            proxy.Open();

            //Get data from database with selected dates and times
            CPUDateArrayList = proxy.GetBeginTimeListForCPUTemp();
            CPUTempArrayList = proxy.GetMaxListForCPUTemp();

            proxy.Close();

            //Serialize arraylists so they can be used in JavaScript
            Serialize(CPUDateArrayList);
            Serialize(CPUTempArrayList);
        }

       

        //  SERIALIZER JAVASCRIPT
        public static string Serialize(object o)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(o);
        }
    }
}