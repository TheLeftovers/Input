using NHibernate.Cfg;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml.Serialization;

namespace Service
{
    /// <summary>
    /// Summary description for getterService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class getterService : System.Web.Services.WebService
    {

        [WebMethod]
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
                var poslist = session.CreateCriteria<Positions>().SetMaxResults(max).SetFetchSize(50).AddOrder(Order.Desc("Speed")).List();

                foreach (Positions pos in poslist)
                {
                    Positions P = session.Get<Positions>(pos.UnitId);
                    Position.Add(P);
                }

                poslist.Clear();
                tx.Commit();
                Position.TrimExcess();
                return Position;

                
            }
        }
    }
}
