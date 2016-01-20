using Npgsql;
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
            ArrayList unitlist = new ArrayList();
            ArrayList datelist = new ArrayList();


            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");

            if (WebApplication.SiteMaster.LoggedIn)
            {
                AnonymousContent.Visible = false;
                AuthorizedContent.Visible = true;

                conn.Open();

                // Define query
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT unit_id, date FROM positions ORDER BY unit_id, date ASC", conn);


                // Execute query
                NpgsqlDataReader dr = cmd.ExecuteReader();


                //Get rows and place in ArrayList
                while (dr.Read())
                {
                    unitlist.Add(dr[0]);
                    datelist.Add(dr[1]);
                }

                // Close connection
                conn.Close();

                for (int i = 0; i < unitlist.Count; i++)
                {
                    DropDownUnit.Items.Add(unitlist[i].ToString());
                    DropDownDate.Items.Add(datelist[i].ToString());
                }
            }
            else
            {
                AnonymousContent.Visible = true;
                AuthorizedContent.Visible = false;
            }

            
            

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

        public void CreateMap()
        {
            GetterService.GetterClient proxy = new GetterService.GetterClient();

            proxy.Open();
            LatLonArrayList = proxy.GetLatLon(long.Parse(DropDownUnit.SelectedItem.Text), DropDownDate.SelectedItem.Text, DropDownBegin.SelectedItem.Text, DropDownEnd.SelectedItem.Text);

            proxy.Close();
            Serialize(LatLonArrayList);
        }

        public static string Serialize(object o)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(o);
        }

        protected void createMap_Click(object sender, EventArgs e)
        {
            CreateMap();
        }
    }
}