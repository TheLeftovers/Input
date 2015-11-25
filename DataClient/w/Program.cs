using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace w
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Server=localhost;database=project56;user id=postgres;password=root";
                x.Driver<NHibernate.Driver.NpgsqlDriver>();
                x.Dialect<NHibernate.Dialect.PostgreSQLDialect>();
            });
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sessionFactory = cfg.BuildSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var positions = session.CreateCriteria<Positions>()
                        .List<Positions>();
                    foreach (var pos in positions)
                    {
                        Console.WriteLine("Units: " + pos.UnitId.ToString() + "\n" + "Speed:" + pos.Speed.ToString() + "\n");
                    }
                    tx.Commit();
                }
                Console.WriteLine("Press <ENTER> to exit...");
                Console.ReadLine();
            }
        }
    }
}
