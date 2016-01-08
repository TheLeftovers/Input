using Npgsql;
using System.Collections;

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

        public ArrayList GetMaxTempList()
        {
            ArrayList temp = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT max FROM monitoring WHERE unit_id = 14100064 AND type = 'Hardware/ProcessorTemperature' ORDER BY max DESC LIMIT 1000", conn);


            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        temp.Add(dr[i]);
                    }
                }
            }


            // Close connection
            conn.Close();

            return temp;
        }

        public ArrayList GetMinTempList()
        {
            ArrayList temp = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT min FROM monitoring WHERE unit_id = 14100064 AND type = 'Hardware/ProcessorTemperature' AND min != 0 ORDER BY min ASC LIMIT 1000", conn);


            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        temp.Add(dr[i]);
                    }
                }
            }


            // Close connection
            conn.Close();

            return temp;
        }

        public ArrayList GetMaxTimeList()
        {
            ArrayList Time = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT begin_time FROM monitoring WHERE unit_id = 14100064 AND type = 'Hardware/ProcessorTemperature' AND date = '' ORDER BY max DESC LIMIT 1000", conn);


            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Time.Add(dr[i]);
                    }
                }
            }


            // Close connection
            conn.Close();

            return Time;
        }

        public ArrayList GetMinTimeList()
        {
            ArrayList Time = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT begin_time FROM monitoring WHERE unit_id = 14100064 AND type = 'Hardware/ProcessorTemperature' AND min != 0 ORDER BY min ASC LIMIT 1000", conn);


            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Time.Add(dr[i]);
                    }
                }
            }


            // Close connection
            conn.Close();

            return Time;
        }

        public ArrayList GetHDOPList()
        {
            ArrayList hdop = new ArrayList();

            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;");
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT hdop, num_satellites FROM positions ORDER BY hdop DESC LIMIT 1000", conn);


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
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT hdop, num_satellites FROM positions ORDER BY hdop DESC LIMIT 1000", conn);


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
