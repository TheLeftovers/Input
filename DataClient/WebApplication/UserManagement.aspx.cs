using NHibernate.Cfg;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class UserManagement : System.Web.UI.Page
    {
        ArrayList maillist = new ArrayList();
        ArrayList passwordlist = new ArrayList();
        ArrayList ranklist = new ArrayList();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SiteMaster.Rank == "2" && SiteMaster.LoggedIn)
            {
                // Specify connection options and open an connection
                NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                        "Password=root;Database=project56;");
                conn.Open();

                // Define query
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM users", conn);

                // Execute query
                NpgsqlDataReader dr = cmd.ExecuteReader();



                //Get rows and place in ArrayList
                while (dr.Read())
                {
                    maillist.Add(dr[0]);
                    passwordlist.Add(dr[1]);
                    ranklist.Add(dr[2]);
                }

                // Close connection
                conn.Close();

             
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cell = new HtmlTableCell();

                row = new HtmlTableRow();
                cell = new HtmlTableCell();

                cell.InnerText = "Email";
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerText = "Wachtwoord";
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerText = "Rank";
                row.Cells.Add(cell);

                tableContent.Rows.Add(row);

                for (int i = 0; i < maillist.Count; i++)
                {
                    row = new HtmlTableRow();
                    cell = new HtmlTableCell();
                    row.Height = "40";
                    cell.InnerText = maillist[i].ToString();
                    row.Cells.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerText = passwordlist[i].ToString();
                    row.Cells.Add(cell);

                    cell = new HtmlTableCell();
                    int secondoption;
                    int thirdoption;
                    if (ranklist[i].ToString() == "0")
                    {
                        secondoption = 1;
                        thirdoption = 2;
                    }
                    else if (ranklist[i].ToString() == "1")
                    {
                        secondoption = 0;
                        thirdoption = 2;
                    }
                    else
                    {
                        secondoption = 0;
                        thirdoption = 1;
                    }

                    cell.InnerHtml = "<select id= " + i + "><option value = " + ranklist[i].ToString() + ">" + ranklist[i].ToString() + "</option><option value =" + secondoption + ">" + secondoption + "</option><option value =" + thirdoption + ">" + thirdoption + "</option></select>";

                    row.Cells.Add(cell);

                    tableContent.Rows.Add(row);
                }

            }

        }
    }
}