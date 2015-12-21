using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class Getter : IGetter
    {
        public List<Positions> GetPositionsList(int max, string order)
        {
            var cfg = new Configuration()
               .SetProperty(NHibernate.Cfg.Environment.WrapResultSets, Boolean.TrueString);

            List<Positions> Position = new List<Positions>();


            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Server=localhost;database=project56;user id=postgres;password=root";
                x.Driver<NHibernate.Driver.NpgsqlDriver>();
                x.Dialect<NHibernate.Dialect.PostgreSQLDialect>();
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sessionFactory = cfg.BuildSessionFactory();


            using (ISession session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {

                var positionlist = session.CreateCriteria<Positions>().SetMaxResults(max).SetFetchSize(100).AddOrder(Order.Desc(order)).List();

                foreach (Positions position in positionlist)
                {
                    Positions P = session.Get<Positions>(position.UnitId);
                    Position.Add(P);
                }

                tx.Commit();
                return Position;
            }
        }
    }
}
