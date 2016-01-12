﻿using Npgsql;
using System;
using System.Collections;
using System.Data;
using System.ServiceModel.Activation;

namespace ServiceLibrary
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Getter : IGetter
    {
        public ArrayList GetUnitList()
        {
            ArrayList Position = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;Buffer Size=100000;");
            conn.Open();

 
            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT unit_id FROM positions ORDER BY speed DESC LIMIT 50", conn);

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
                                    "Password=root;Database=project56;Buffer Size=100000;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT speed FROM positions ORDER BY speed DESC LIMIT 50", conn);


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


        public ArrayList GetUnitListbyRepair()
        {
            ArrayList Unit = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT unit_id FROM events WHERE port = 'Ignition' GROUP BY unit_id  HAVING COUNT(*) >= 60", conn);


            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Unit.Add(dr[i]);
                    }
                }
            }


            // Close connection
            conn.Close();

            return Unit;
        }

        public ArrayList GetCountListbyRepair()

        {
            ArrayList Count = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(*) FROM events WHERE port = 'Ignition' GROUP BY unit_id  HAVING COUNT(*) >= 60", conn);


            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Count.Add(dr[i]);
                    }
                }
            }


            // Close connection
            conn.Close();

            return Count;
        }

        public ArrayList GetHDOPList()
        {
            ArrayList hdop = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT hdop, num_satellites FROM positions ORDER BY hdop DESC LIMIT 200", conn);


            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    hdop.Add(dr[0]);
                    /*
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        hdop.Add(dr[i]);
                    }
                    */
                }
            }


            // Close connection
            conn.Close();

            return hdop;
        }

        public ArrayList GetNumSatellitesList()
        {
            ArrayList sat = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT hdop, num_satellites FROM positions ORDER BY hdop DESC LIMIT 200", conn);


            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    sat.Add(dr[1]);
                    /*
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        sat.Add(dr[i]);
                    }
                    */
                }
            }


            // Close connection
            conn.Close();

            return sat;
        }
    }
}
