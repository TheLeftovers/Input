using Npgsql;
using System;
using System.Collections;
using System.Web.UI;

namespace WebApplication.Account
{
    public partial class Register : Page
    {
        public bool EmailUnique = true;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //ArrayList for emails
            ArrayList maillist = new ArrayList();


            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");

            //Open connection
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT email FROM users", conn);

            // Execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();


            //Get rows and place in ArrayList
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    maillist.Add(dr[i]);
                }
            }

            // Close connection
            conn.Close();

            //Check if email in TextBox equals one of the existing accounts
            for (int i = 0; i < maillist.Count; i++)
            {
                if (maillist[i].Equals(Email.Text))
                {
                    EmailUnique = false;
                    MessageBox.Show(Page, "Dit emailadres is al geregistreerd!");
                    break;
                }
            }

            if (EmailUnique)
            {
                //Insert Email and Password from TextBoxes
                conn.Open();

                NpgsqlCommand cmd1 = new NpgsqlCommand("INSERT INTO users(email, password, rank) VALUES (:email, :pw, 0)", conn);
                cmd1.Parameters.Add(new NpgsqlParameter("email", Email.Text));
                cmd1.Parameters.Add(new NpgsqlParameter("pw", Password.Text));

                cmd1.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show(Page, "Uw account is geregistreerd!");

            }
        }
    }
}
