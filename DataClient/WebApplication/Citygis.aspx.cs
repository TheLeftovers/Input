using Npgsql;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebApplication.SiteMaster.LoggedIn)
            {
                //Show divs when logged in
                AnonymousContent.Visible = false;
                AuthorizedContent.Visible = true;

                //Create proxy
                GetterClient proxy = new GetterClient();

                proxy.Open();

                //Fill array with database rows from WCF
                ConnBoolTrueArrayList = proxy.GetQueryList("SELECT COUNT(value) FROM connections WHERE value = 'True'");
                ConnBoolFalseArrayList = proxy.GetQueryList("SELECT COUNT(value) FROM connections WHERE value = 'False'");

                proxy.Close();

                //Serialize arraylists so they can be used in JavaScript
                Serialize(ConnBoolTrueArrayList);
                Serialize(ConnBoolFalseArrayList);

                FillTable();
                FillDropDownChart3();
                FillDropDownChart4();
            }
            else
            {
                AnonymousContent.Visible = true;
                AuthorizedContent.Visible = false;
            }
        }

        //  CREATE TABLE METHOD
        public void FillTable()
        {
            //Create proxy
            GetterClient proxy = new GetterClient();

            //Open connection
            proxy.Open();

            //Create table cells and place unit id's 
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

        //  ADD ITEMS TO DDL METHODS
        public void FillDropDownChart3()
        {
            //Clear dropdown to prevent duplicates
            DropDownDate.Items.Clear();

            ArrayList datelist = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");

            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT LEFT(begin_time, 10) as bdates FROM monitoring ORDER BY bdates ASC", conn);

            // Execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            //Get rows and place in ArrayList
            while (dr.Read())
            {
                datelist.Add(dr[0]);
            }

            // Close connection
            conn.Close();

            for (int i = 0; i < datelist.Count; i++)
            {
                DropDownDate.Items.Add(datelist[i].ToString());     //Add dates from database to dropdown
            }

            //Add dropdown items(hours)
            DropDownBegin.Items.Add("00:00");
            DropDownBegin.Items.Add("01:00");
            DropDownBegin.Items.Add("02:00");
            DropDownBegin.Items.Add("03:00");
            DropDownBegin.Items.Add("04:00");
            DropDownBegin.Items.Add("05:00");
            DropDownBegin.Items.Add("06:00");
            DropDownBegin.Items.Add("07:00");
            DropDownBegin.Items.Add("08:00");
            DropDownBegin.Items.Add("09:00");
            DropDownBegin.Items.Add("10:00");
            DropDownBegin.Items.Add("11:00");
            DropDownBegin.Items.Add("12:00");
            DropDownBegin.Items.Add("13:00");
            DropDownBegin.Items.Add("14:00");
            DropDownBegin.Items.Add("15:00");
            DropDownBegin.Items.Add("16:00");
            DropDownBegin.Items.Add("17:00");
            DropDownBegin.Items.Add("18:00");
            DropDownBegin.Items.Add("19:00");
            DropDownBegin.Items.Add("20:00");
            DropDownBegin.Items.Add("21:00");
            DropDownBegin.Items.Add("22:00");
            DropDownBegin.Items.Add("23:00");

            DropDownEnd.Items.Add("00:00");
            DropDownEnd.Items.Add("01:00");
            DropDownEnd.Items.Add("02:00");
            DropDownEnd.Items.Add("03:00");
            DropDownEnd.Items.Add("04:00");
            DropDownEnd.Items.Add("05:00");
            DropDownEnd.Items.Add("06:00");
            DropDownEnd.Items.Add("07:00");
            DropDownEnd.Items.Add("08:00");
            DropDownEnd.Items.Add("09:00");
            DropDownEnd.Items.Add("10:00");
            DropDownEnd.Items.Add("11:00");
            DropDownEnd.Items.Add("12:00");
            DropDownEnd.Items.Add("13:00");
            DropDownEnd.Items.Add("14:00");
            DropDownEnd.Items.Add("15:00");
            DropDownEnd.Items.Add("16:00");
            DropDownEnd.Items.Add("17:00");
            DropDownEnd.Items.Add("18:00");
            DropDownEnd.Items.Add("19:00");
            DropDownEnd.Items.Add("20:00");
            DropDownEnd.Items.Add("21:00");
            DropDownEnd.Items.Add("22:00");
            DropDownEnd.Items.Add("23:00");

        }

        public void FillDropDownChart4()
        {
            //Clear dropdown to prevent duplicates
            DropDownDate2.Items.Clear();

            ArrayList datelist1 = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");

            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT LEFT(begin_time, 10) as bdates FROM monitoring WHERE type='Hardware/ProcessorTemperature' ORDER BY bdates ASC", conn);

            // Execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            //Get rows and place in ArrayList
            while (dr.Read())
            {
                datelist1.Add(dr[0]);
            }

            // Close connection
            conn.Close();

            for (int i = 0; i < datelist1.Count; i++)
            {
                DropDownDate2.Items.Add(datelist1[i].ToString());   //Add dates from database to dropdown
            }

            //Add dropdown items(hours)
            DropDownBegin2.Items.Add("00:00");
            DropDownBegin2.Items.Add("01:00");
            DropDownBegin2.Items.Add("02:00");
            DropDownBegin2.Items.Add("03:00");
            DropDownBegin2.Items.Add("04:00");
            DropDownBegin2.Items.Add("05:00");
            DropDownBegin2.Items.Add("06:00");
            DropDownBegin2.Items.Add("07:00");
            DropDownBegin2.Items.Add("08:00");
            DropDownBegin2.Items.Add("09:00");
            DropDownBegin2.Items.Add("10:00");
            DropDownBegin2.Items.Add("11:00");
            DropDownBegin2.Items.Add("12:00");
            DropDownBegin2.Items.Add("13:00");
            DropDownBegin2.Items.Add("14:00");
            DropDownBegin2.Items.Add("15:00");
            DropDownBegin2.Items.Add("16:00");
            DropDownBegin2.Items.Add("17:00");
            DropDownBegin2.Items.Add("18:00");
            DropDownBegin2.Items.Add("19:00");
            DropDownBegin2.Items.Add("20:00");
            DropDownBegin2.Items.Add("21:00");
            DropDownBegin2.Items.Add("22:00");
            DropDownBegin2.Items.Add("23:00");

            DropDownEnd2.Items.Add("00:00");
            DropDownEnd2.Items.Add("01:00");
            DropDownEnd2.Items.Add("02:00");
            DropDownEnd2.Items.Add("03:00");
            DropDownEnd2.Items.Add("04:00");
            DropDownEnd2.Items.Add("05:00");
            DropDownEnd2.Items.Add("06:00");
            DropDownEnd2.Items.Add("07:00");
            DropDownEnd2.Items.Add("08:00");
            DropDownEnd2.Items.Add("09:00");
            DropDownEnd2.Items.Add("10:00");
            DropDownEnd2.Items.Add("11:00");
            DropDownEnd2.Items.Add("12:00");
            DropDownEnd2.Items.Add("13:00");
            DropDownEnd2.Items.Add("14:00");
            DropDownEnd2.Items.Add("15:00");
            DropDownEnd2.Items.Add("16:00");
            DropDownEnd2.Items.Add("17:00");
            DropDownEnd2.Items.Add("18:00");
            DropDownEnd2.Items.Add("19:00");
            DropDownEnd2.Items.Add("20:00");
            DropDownEnd2.Items.Add("21:00");
            DropDownEnd2.Items.Add("22:00");
            DropDownEnd2.Items.Add("23:00");

        }

        //  CREATE CHART METHODS
        public void CreateChart3()
        {
            //Get selected items and their value from dropdowns and use to create string
            string begin = DropDownDate.SelectedValue + " " + DropDownBegin.SelectedValue;
            string end = DropDownDate.SelectedValue + " " + DropDownEnd.SelectedValue;

            //Create proxy
            GetterClient proxy = new GetterClient();

            //Open connection
            proxy.Open();

            //Get data from database with selected dates and times
            DateArrayList = proxy.GetBeginTimeListForGPSTemp(begin, end);
            TempArrayList = proxy.GetMaxListForGPSTemp(begin, end);

            proxy.Close();

            //Serialize arraylists so they can be used in JavaScript
            Serialize(DateArrayList);
            Serialize(TempArrayList);
        }

        public void CreateChart4()
        {
            //Get selected items and their value from dropdowns and use to create string
            string begin = DropDownDate2.SelectedValue + " " + DropDownBegin2.SelectedValue;
            string end = DropDownDate2.SelectedValue + " " + DropDownEnd2.SelectedValue;

            //Create proxy
            GetterClient proxy = new GetterClient();

            //Open connection
            proxy.Open();

            //Get data from database with selected dates and times
            CPUDateArrayList = proxy.GetBeginTimeListForCPUTemp(begin, end);
            CPUTempArrayList = proxy.GetMaxListForCPUTemp(begin, end);

            proxy.Close();

            //Serialize arraylists so they can be used in JavaScript
            Serialize(CPUDateArrayList);
            Serialize(CPUTempArrayList);
        }

        //  CREATE CHART BUTTONS
        protected void chart3Button_Click(object sender, EventArgs e)
        {
            CreateChart3();
        }

        protected void chart4Button_Click(object sender, EventArgs e)
        {
            CreateChart4();
        }

        //  SERIALIZER JAVASCRIPT
        public static string Serialize(object o)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(o);
        }
    }
}