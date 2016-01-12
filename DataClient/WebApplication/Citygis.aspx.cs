using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using WebApplication.GetterService;

namespace WebApplication
{
    public partial class Citygis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebApplication.SiteMaster.LoggedIn)
            {
                AnonymousContent.Visible = false;
                AuthorizedContent.Visible = true;
                FillTable();
            }
            else
            {
                AnonymousContent.Visible = true;
                AuthorizedContent.Visible = false;
            }
        }

        public void FillTable()
        {
            //Create proxy
            GetterClient proxy = new GetterClient();

            //Open connection
            proxy.Open();

            for(int i=0; i<9; i++)
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