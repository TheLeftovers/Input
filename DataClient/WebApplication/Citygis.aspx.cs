using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebApplication.SiteMaster.LoggedIn)
            {
                AnonymousContent.Visible = false;
                AuthorizedContent.Visible = true;
                FillTable();

                GetterClient proxy = new GetterClient();

                proxy.Open();

                ConnBoolTrueArrayList = proxy.GetQueryList("SELECT COUNT(value) FROM connections WHERE value = 'True'");
                ConnBoolFalseArrayList = proxy.GetQueryList("SELECT COUNT(value) FROM connections WHERE value = 'False'");
                DateArrayList = proxy.GetBeginTimeList();
                TempArrayList = proxy.GetMaxList();


                proxy.Close();

                Serialize(ConnBoolTrueArrayList);
                Serialize(ConnBoolFalseArrayList);
                Serialize(DateArrayList);
                Serialize(TempArrayList);
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

        public void FillTable()
        {
            //Create proxy
            GetterClient proxy = new GetterClient();

            //Open connection
            proxy.Open();

            for (int i = 0; i < 9; i++)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = proxy.GetUnitListbyRepair()[i].ToString();
                row.Cells.Add(cell);
                Table1.Rows.Add(row);
            }

            proxy.Close();
        }
    }
}