﻿using NHibernate;
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

        [WebGet]
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
