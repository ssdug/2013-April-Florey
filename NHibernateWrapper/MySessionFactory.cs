using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.ByteCode.Castle;

namespace NHibernateWrapper
{
    public sealed class MySessionFactory
    {
        #region Data Members

        private ISessionFactory _sessionFactory;
        //        ProxyFactory px = new ProxyFactory(); // added this to make the correct dll copy.

        #endregion Data Members
        #region Public Instance

        public static MySessionFactory Instance
        {
            get { return Nested.NhibernateConnection; }
        }

        #endregion Public Instance

        #region Private constructor

        private MySessionFactory()
        {
        }

        #endregion Private Constructor

        #region Private Methods

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private class Nested
        {
            internal static readonly MySessionFactory NhibernateConnection =
                new MySessionFactory();
        }

        private static void LoadAssembly(string assemblyAppSettingKey, NHibernate.Cfg.Configuration configuration)
        {
            try
            {
                configuration.AddAssembly("DataDriver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            }
            catch (Exception ex)
            {
                Trace.TraceInformation(ex.Message);
            }
        }

        #endregion Private Methods

        #region Public Methods

        public ISession GetSession()
        {
            if (Equals(null, _sessionFactory))
            {
                InitSessionFactory();
            }
            return Equals(null, this._sessionFactory) ? null : this._sessionFactory.OpenSession();
        }

        public void InitSessionFactory()
        {
            try
            {
                string connectionString = "Data Source=Pets.sdf";
                string owner = String.Empty;

                NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
                configuration.Properties.Add("dialect", "NHibernate.Dialect.MsSqlCeDialect");
                configuration.Properties.Add("connection.driver_class", "NHibernate.Driver.SqlServerCeDriver");
                AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);

                configuration.Properties.Add("proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle");
                configuration.Properties.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                configuration.Properties.Add("connection.connection_string", connectionString);
                configuration.Properties.Add("show_sql", "true");
                configuration.AddAssembly("DataDriver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

                //ToDo :: Add more entity assembly keys if you nHibernate stuff crashes and you don't know why...

                _sessionFactory = configuration.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Trace.TraceInformation("Creating the session factory failed with {0}", ex.Message);
            }

        }

        #endregion Public Methods
    }
}
