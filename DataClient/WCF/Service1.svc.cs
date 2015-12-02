using NHibernate.Cfg;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
       
        [WebGet]
        public List<Positions> GetPositionsList(int max, string order)
        {
            var cfg = new Configuration();
            List<Positions> Position = new List<Positions>();


            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Server=localhost;database=project56;user id=postgres;password=root";
                x.Driver<NHibernate.Driver.NpgsqlDriver>();
                x.Dialect<NHibernate.Dialect.PostgreSQLDialect>();
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sessionFactory = cfg.BuildSessionFactory();

            
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var poslist = session.CreateCriteria<Positions>().SetMaxResults(max).SetFetchSize(50).AddOrder(Order.Desc(order)).List();

                foreach (Positions pos in poslist)
                {
                    Positions P = session.Get<Positions>(pos.UnitId);
                    Position.Add(P);
                }

                poslist.Clear();
                tx.Commit();
                return Position;


            }
        }
    }
}
