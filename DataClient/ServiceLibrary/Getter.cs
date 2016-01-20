using Npgsql;
using System.Collections;
using System.ServiceModel.Activation;

namespace ServiceLibrary
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Getter : IGetter
    {
        // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;" +
                                    "Password=root;Database=project56;Buffer Size=100000;");


        public ArrayList GetTestList()
        {
            ArrayList test = new ArrayList();
            test.Add("1");
            test.Add("2");
            test.Add("3");
            test.Add("4");
            test.Add("5");
            test.Add("6");
            test.Add("7");
            test.Add("8");
            test.Add("9");
            test.Add("10");

            return test;
        }

        public ArrayList GetQueryList(string query)
        {
            ArrayList Position = new ArrayList();

            //Open connection
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

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


        public ArrayList GetUnitListForTopSpeed()
        {
            ArrayList Position = new ArrayList();

            //Open connection
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

        public ArrayList GetLatLon(long unit, string date, string from, string till)
        {
            ArrayList Position = new ArrayList();

            //Open connection
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT rd_x, rd_y FROM positions WHERE unit_id = '" + unit + "' AND date ='" + date + "' AND time BETWEEN '" + from + "' AND '" + till + "' ", conn);
            int cnt = 0;
            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read() && cnt < 20000)
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Position.Add(dr[i]);
                    }
                    cnt++;
                }
            }

            // Close connection
            conn.Close();

            return Position;
        }

        public ArrayList GetSpeedListForTopSpeed()
        {
            ArrayList Position = new ArrayList();

            //Open connection
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

            //Open connection
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

            //Open connection
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

            //Open connection
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
                }
            }

            // Close connection
            conn.Close();

            return hdop;
        }

        public ArrayList GetNumSatellitesList()
        {
            ArrayList sat = new ArrayList();

            //Open connection
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
                }
            }

            // Close connection
            conn.Close();

            return sat;
        }

        public ArrayList GetBeginTimeListForGPSTemp()
        {
            ArrayList beginTime = new ArrayList();

            //Open connection
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT begin_time, max FROM monitoring WHERE (begin_time BETWEEN '2015-03-10 07:00' AND '2015-03-10 08:00') AND type='Gps/GpsTemperature' ORDER BY begin_time,  max", conn);

            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    beginTime.Add(dr[0]);
                    }
                }

            // Close connection
            conn.Close();

            return beginTime;
        }

        public ArrayList GetMaxListForGPSTemp()
        {
            ArrayList Max = new ArrayList();

            //Open connection
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT begin_time, max FROM monitoring WHERE (begin_time BETWEEN '2015-03-10 07:00' AND '2015-03-10 08:00') AND type='Gps/GpsTemperature' ORDER BY begin_time, max ", conn);

            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    Max.Add(dr[1]);
                }
            }

            // Close connection
            conn.Close();

            return Max;
        }

        public ArrayList GetBeginTimeListForCPUTemp()
        {
            ArrayList beginTime = new ArrayList();

            //Open connection
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT begin_time, max FROM monitoring WHERE (begin_time BETWEEN '2015-03-10 07:00' AND '2015-03-10 08:00') AND type='Hardware/ProcessorTemperature' ORDER BY begin_time, max ASC", conn);

            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    beginTime.Add(dr[0]);
                }
            }

            // Close connection
            conn.Close();

            return beginTime;
        }

        public ArrayList GetMaxListForCPUTemp()
        {
            ArrayList Max = new ArrayList();

            //Open connection
            conn.Open();

            // Define query
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT begin_time, max FROM monitoring WHERE (begin_time BETWEEN '2015-03-10 07:00' AND '2015-03-10 08:00') AND type='Hardware/ProcessorTemperature' ORDER BY begin_time, max ASC", conn);

            // Execute query
            using (NpgsqlDataReader dr = cmd.ExecuteReader())
            {
                // Get rows and place in ArrayList
                while (dr.Read())
                {
                    Max.Add(dr[1]);
                }
            }

            // Close connection
            conn.Close();

            return Max;
        }


    }
}
