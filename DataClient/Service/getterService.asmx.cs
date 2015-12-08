using NHibernate;
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
            var cfg = new Configuration()
                .SetProperty(NHibernate.Cfg.Environment.FormatSql, Boolean.FalseString).
                SetProperty(NHibernate.Cfg.Environment.GenerateStatistics, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.Hbm2ddlKeyWords, Hbm2DDLKeyWords.None.ToString())
                .SetProperty(NHibernate.Cfg.Environment.PrepareSql, Boolean.TrueString)
                .SetProperty(NHibernate.Cfg.Environment.PropertyBytecodeProvider, "lcg")
                .SetProperty(NHibernate.Cfg.Environment.PropertyUseReflectionOptimizer, Boolean.TrueString)
                .SetProperty(NHibernate.Cfg.Environment.QueryStartupChecking, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.ShowSql, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.UseProxyValidator, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.UseSecondLevelCache, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.UseSqlComments, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.UseQueryCache, Boolean.FalseString)
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


            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.CacheMode = CacheMode.Ignore;
                session.FlushMode = FlushMode.Never;
                session.DefaultReadOnly = true;

                var positionlist = session.CreateCriteria<Positions>().SetMaxResults(max).SetFetchSize(100).AddOrder(Order.Desc(order)).List();

                foreach (Positions position in positionlist)
                {
                    Positions P = session.Get<Positions>(position.UnitId);
                    Position.Add(P);
                }

                positionlist.Clear();
                tx.Commit();
                Position.TrimExcess();
                return Position;
            }
        }

        [WebMethod]
        public List<Events> GetEventsList(int max, string order)
        {
            var cfg = new Configuration()
                .SetProperty(NHibernate.Cfg.Environment.FormatSql, Boolean.FalseString).
                SetProperty(NHibernate.Cfg.Environment.GenerateStatistics, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.Hbm2ddlKeyWords, Hbm2DDLKeyWords.None.ToString())
                .SetProperty(NHibernate.Cfg.Environment.PrepareSql, Boolean.TrueString)
                .SetProperty(NHibernate.Cfg.Environment.PropertyBytecodeProvider, "lcg")
                .SetProperty(NHibernate.Cfg.Environment.PropertyUseReflectionOptimizer, Boolean.TrueString)
                .SetProperty(NHibernate.Cfg.Environment.QueryStartupChecking, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.ShowSql, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.UseProxyValidator, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.UseSecondLevelCache, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.UseSqlComments, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.UseQueryCache, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.WrapResultSets, Boolean.TrueString);

            List<Events> Event = new List<Events>();

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
                session.CacheMode = CacheMode.Ignore;
                session.FlushMode = FlushMode.Never;
                session.DefaultReadOnly = true;

                var eventlist = session.CreateCriteria<Events>().SetMaxResults(max).SetFetchSize(100).AddOrder(Order.Desc(order)).List();

                foreach (Events ev in eventlist)
                {
                    Events E = session.Get<Events>(ev.UnitId);
                    Event.Add(E);
                }

                eventlist.Clear();
                tx.Commit();
                Event.TrimExcess();
                return Event;
            }
        }
    }
}
