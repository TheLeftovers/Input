using Npgsql;
using System;
using System.Collections;
using System.Diagnostics;
using System.Web.UI.HtmlControls;

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
                    ranklist.Add(dr[2]);
                }

                // Close connection
                conn.Close();

                for(int i=0;i<maillist.Count;i++)
                {
                    maildrop.Items.Add(maillist[i].ToString());
                }

              

            }

        }

        protected void UpdateUser(object sender, EventArgs e)
        {
            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");

            //Insert Email and Password from TextBoxes
            conn.Open();

            NpgsqlCommand cmd1 = new NpgsqlCommand("UPDATE users SET rank = :rank WHERE email = :email", conn);
            cmd1.Parameters.Add(new NpgsqlParameter("email", maildrop.SelectedItem.Text));
            cmd1.Parameters.Add(new NpgsqlParameter("rank", rankdrop.SelectedItem.Text));

            cmd1.ExecuteNonQuery();

            conn.Close();
        }

    }
}