using NHibernate.Cfg;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
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
        [XmlInclude(typeof(Positions))]
        public List<Positions> GetPositionsList(int max)
        {
            var cfg = new Configuration();
            List<Positions> Positions = new List<Positions>();

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
                var poslist = session.CreateCriteria<Positions>().SetMaxResults(max).SetFetchSize(1000).AddOrder(Order.Desc("Speed")).List();

                foreach (Positions pos in poslist)
                {
                    Positions positions = session.Get<Positions>(pos.UnitId);
                    Positions.Add(positions);
                }


                tx.Commit();
                session.Connection.Close();
                session.Close();


                return Positions;
            }
        }
    }
}
