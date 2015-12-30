using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class Getter : IGetter
    {
        public ArrayList GetUnitList()
        {
            ArrayList Position = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT unit_id FROM positions ORDER BY speed DESC LIMIT 10000", conn);


            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Position.Add(dr[i]);
                    }
                }
            }


            // Close connection
            conn.Close();

            return Position;
        }

        public ArrayList GetSpeedList()
        {
            ArrayList Position = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT speed FROM positions ORDER BY speed DESC LIMIT 10000", conn);


            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Position.Add(dr[i]);
                    }
                }
            }

            // Close connection
            conn.Close();

            return Position;
        }
    }
}
