using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.ByteCode.Castle;

namespace NHibernateWrapper
{
    public class NHibernateTest
    {
        #region Data Members

        private ISession _session;
        private ITransaction _transaction;

        #endregion Data Members

        #region Public Methods

        #region Session and transaction handling methods

        /// <summary>
        /// Generic data entity save function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to save.</typeparam>
        /// <param name="entity">The entity to save.</param>
        /// <param name="session">Session to use.</param>
        public static void Save<TE>(TE entity, ISession session)
        {
            int attempts = 0;

            if (null == session)
            {
                throw new Exception(string.Intern("Could not create database connection."));
            }

            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Save(entity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Trace.TraceInformation("Saving failed with {0}", ex.Message);
                }
                finally
                {
                    if (null != transaction && transaction.IsActive)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        /// <summary>
        /// Generic data entity load function.
        /// We are casting the list to a list of objects so it works with
        /// reflection in the calling method (the generic type being used
        /// has to be declared at compile time, but since we are using
        /// reflection to come up with the object type, we can't do that 
        /// in this case).
        /// </summary>
        /// <typeparam name="T">The type of the entity to load.</typeparam>
        /// <param name="selectClause">The where clause to use.</param>
        /// <param name="session">Session to use.</param>
        /// <returns>The entity.</returns>
        public static List<object> Load<T>(string selectClause, ISession session)
        {
            if (null == session)
            {
                Debug.WriteLine("Could not create database connection.");
                throw new Exception(string.Intern("Could not create database connection."));
            }

            try
            {
                if (string.IsNullOrEmpty(selectClause))
                {
                    string[] splits = typeof(T).ToString().Split(new[] { '.' });
                    if (splits.Length >= 1)
                    {
                        selectClause = " FROM " + splits[splits.Length - 1];
                    }
                    else
                    {
                        throw new ArgumentException("Invalid Select Clause");
                    }
                }

                List<T> tempList = (List<T>)session.CreateQuery(selectClause).List<T>();
                List<object> retList = new List<object>(tempList.Count);
                for (int i = 0; i < tempList.Count; i++)
                {
                    retList.Add(tempList[i]);
                }
                return (retList);
            }
            catch (Exception e)
            {
                Debug.WriteLine(String.Format("Error when trying to load Entity {0}.  Message: {1}.",
                                          typeof(T).Name,
                                          e.Message));
                throw;
            }
        }

        /// <summary>
        /// Generic data entity load function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to load.</typeparam>
        /// <param name="key">The key for the entity.</param>
        /// <param name="session">Session to use.</param>
        /// <returns>The entity.</returns>
        public static TE Load<TE>(int key, ISession session)
        {
            //  NASTY HACK ALERT!!
            //  For some reason, every now and then NHibernate is not finding an entity with the given key on the first
            //  try, but it finds it OK after that.  I have no idea why so I did this ugly bad thing to fix that.  BleahX2.
            //  -----------------------------------------------------------------------------------------------------------
            int count = 0;
            do
            {
                if (null == session)
                {
                    Debug.WriteLine("Could not create database connection.");
                    throw new Exception(string.Intern("Could not create database connection."));
                }

                try
                {
                    return session.Get<TE>(key);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(string.Format("Error when trying to load Entity {0}.  Message: {1}.\r\nCount=" + count,
                                              typeof(TE).Name, e.Message));
                    if (count++ >= 2)
                    {
                        throw;
                    }
                }
            }
            while (count < 2);

            throw new ArgumentException(string.Format("Could not find entity {0} with the key of {1}", typeof(TE), key));
        }

        public static void Delete<TE>(string deleteClause, ISession session)
        {
            if (null == session)
            {
                Debug.WriteLine("Could not create database connection.");
                throw new Exception(string.Intern("Could not create database connection."));
            }

            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Delete(deleteClause);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("Error when trying to delete entity {0}.  Message: {1}.",
                                              typeof(TE).Name, ex.Message));
                    throw;
                }
                finally
                {
                    if (null != transaction && transaction.IsActive)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        /// <summary>
        /// Generic data entity save or update function.
        /// NOTE:  Use the Save method the first time the entity is saved.  It works better.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to save or update.</typeparam>
        /// <param name="entity">The entity to save or update.</param>
        /// <param name="session">Session to use.</param>
        public static void Update<TE>(TE entity, ISession session)
        {
            if (null == session)
            {
                Debug.WriteLine("Could not create database connection.");
                throw new Exception(string.Intern("Could not create database connection."));
            }

            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Update(entity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("Error when trying to update entity {0}.  Message: {1}.",
                                              typeof(TE).Name, ex.Message));
                    throw;
                }
                finally
                {
                    if (null != transaction && transaction.IsActive)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }


        #endregion Session and transaction handling methods
        /*
         * 

using Marshall.GeoResultsLibrary.Logging;
using Marshall.GeoResultsLibrary.NHibernateComponents;
using Marshall.GeoResultsLibrary.ConfigurationSettings;


        private static readonly ILogger Logger = LoggerFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public void BeginTransaction()
        {
                _session = NhibernateSessionFactory.Instance.GetSession();
                _transaction = _session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
            _transaction.Dispose();
            _session.Close();
            _session.Dispose();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _session.Close();
            _session.Dispose();
        }

        public void SaveTransact<TE>(TE entity)
        {
            CheckSessionAndTransactionActive();
            _session.Save(entity);
        }

        public void UpdateTransact<TE>(TE entity)
        {
            CheckSessionAndTransactionActive();
            _session.Update(entity);
        }

        public void SaveOrUpdateTransact<TE>(TE entity)
        {
            CheckSessionAndTransactionActive();
            _session.SaveOrUpdate(entity);
        }

        public void DeleteTransact<TE>(TE entity)
        {
            CheckSessionAndTransactionActive();
            _session.Delete(entity);
        }

        private void CheckSessionAndTransactionActive()
        {
            if (null == _session)
            {
                Logger.Log("No current session.", LogLevel.ERROR);
                throw new Exception(string.Intern("No current session."));
            }
            if (!_transaction.IsActive)
            {
                Logger.Log("No active transaction.", LogLevel.ERROR);
                throw new Exception(string.Intern("No active transaction."));
            }
        }

        public bool HasActiveTransaction()
        {
            return _transaction.IsActive;
        }


        /// <summary>
        /// Generic data entity load function.
        /// We are casting the list to a list of objects so it works with
        /// reflection in the calling method (the generic type being used
        /// has to be declared at compile time, but since we are using
        /// reflection to come up with the object type, we can't do that 
        /// in this case).
        /// </summary>
        /// <typeparam name="TE">The type of the entity to load.</typeparam>
        /// <param name="selectClause">The select clause to use.</param>
        /// <returns>The entity.</returns>
        public static List<object> Load<TE>(string selectClause)
        {
            try
            {
                using (ISession session = NhibernateSessionFactory.Instance.GetSession())
                {
                    return Load<TE>(selectClause, session);
                }
            }
            catch (Exception e)
            {
                Logger.Log(String.Format("Error getting default session in Load message was: {0}",
                                          e.Message)
                            , LogLevel.ERROR);
                throw;
            }
        }

        /// <summary>
        /// Generic data entity load function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to load.</typeparam>
        /// <param name="key">The key for the entity.</param>
        /// <returns>The entity.</returns>
        public static TE Load<TE>(int key)
        {
            try
            {
                using (ISession session = NhibernateSessionFactory.Instance.GetSession())
                {
                    return Load<TE>(key, session);
                }
            }
            catch (Exception e)
            {
                Logger.Log(String.Format("Error getting default session in Load message was: {0}",
                                          e.Message)
                            , LogLevel.ERROR);
                throw;
            }
        }

        /// <summary>
        /// Generic data entity load function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to load.</typeparam>
        /// <param name="key">The key for the entity.</param>
        /// <returns>The entity.</returns>
        public static TE Load<TE>(PairIdComponent key)
        {
            try
            {
                using (ISession session = NhibernateSessionFactory.Instance.GetSession())
                {
                    return Load<TE>(key, session);
                }
            }
            catch (Exception e)
            {
                Logger.Log(String.Format("Error getting default session in Load message was: {0}",
                                          e.Message)
                            , LogLevel.ERROR);
                throw;
            }
        }

        /// <summary>
        /// Generic data entity load function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to load.</typeparam>
        /// <param name="key">The key for the entity.</param>
        /// <param name="session">Session to use.</param>
        /// <returns>The entity.</returns>
        public static TE Load<TE>(PairIdComponent key, ISession session)
        {
            if (null == session)
            {
                Logger.Log("Could not create database connection.", LogLevel.ERROR);
                throw new Exception(string.Intern("Could not create database connection."));
            }

            try
            {
                return (TE)session.Load(typeof(TE), key);
            }
            catch (Exception e)
            {
                Logger.Log(string.Format("Error when trying to load Entity {0}.  Message: {1}.",
                                          typeof(TE).Name, e.Message)
                            , LogLevel.ERROR);
                throw;
            }
        }

        /// <summary>
        /// Generic data entity load function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to load.</typeparam>
        /// <param name="key">The key for the entity.</param>
        /// <returns>The entity or null if it isn't found.</returns>
        public static TE LoadOrNull<TE>(int key)
        {
            try
            {
                using (ISession session = NhibernateSessionFactory.Instance.GetSession())
                {
                    return LoadOrNull<TE>(key, session);
                }
            }
            catch (Exception e)
            {
                Logger.Log(String.Format("Error getting default session in LoadOrNull message was: {0}",
                                          e.Message)
                            , LogLevel.ERROR);
                throw;
            }
        }

        /// <summary>
        /// Generic data entity load function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to load.</typeparam>
        /// <param name="key">The key for the entity.</param>
        /// <param name="session">Session to use.</param>
        /// <returns>The entity or null if it isn't found.</returns>
        public static TE LoadOrNull<TE>(int key, ISession session)
        {
            if (null == session)
            {
                Logger.Log("Could not create database connection.", LogLevel.ERROR);
                throw new Exception(string.Intern("Could not create database connection."));
            }

            try
            {
                return (TE)session.Load(typeof(TE), key);
            }
            catch
            {
                return default(TE);
            }
        }

        /// <summary>
        /// Generic data entity load function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to load.</typeparam>
        /// <param name="key">The key for the entity.</param>
        /// <returns>The entity or null if it isn't found.</returns>
        public static TE LoadOrNull<TE>(PairIdComponent key)
        {
            try
            {
                using (ISession session = NhibernateSessionFactory.Instance.GetSession())
                {
                    return LoadOrNull<TE>(key, session);
                }
            }
            catch (Exception e)
            {
                Logger.Log(String.Format("Error getting default session in LoadOrNull message was: {0}",
                                          e.Message)
                            , LogLevel.ERROR);
                throw;
            }
        }

        /// <summary>
        /// Generic data entity load function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to load.</typeparam>
        /// <param name="key">The key for the entity.</param>
        /// <param name="session">Session to use.</param>
        /// <returns>The entity or null if it isn't found.</returns>
        public static TE LoadOrNull<TE>(PairIdComponent key, ISession session)
        {
            if (null == session)
            {
                Logger.Log("Could not create database connection.", LogLevel.ERROR);
                throw new Exception(string.Intern("Could not create database connection."));
            }

            try
            {
                return (TE)session.Load(typeof(TE), key);
            }
            catch
            {
                return default(TE);
            }
        }


        /// <summary>
        /// This method is similar to load, but can return an emtpy list.
        /// It is here more for an example than anything else.
        /// </summary>
        /// <typeparam name="TE"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IList<TE> FindByIdKeys<TE>(PairIdComponent key)
        {
            try
            {
                using (ISession session = NhibernateSessionFactory.Instance.GetSession())
                {
                    return FindByIdKeys<TE>(key, session);
                }
            }
            catch (Exception e)
            {
                Logger.Log(String.Format("Error getting default session in FindByIdKeys message was: {0}",
                                          e.Message)
                            , LogLevel.ERROR);
                throw;
            }
        }

        /// <summary>
        /// This method is similar to load, but can return an emtpy list.
        /// It is here more for an example than anything else.
        /// </summary>
        /// <typeparam name="TE"></typeparam>
        /// <param name="key"></param>
        /// <param name="session">Session to use.</param>
        /// <returns></returns>
        public static IList<TE> FindByIdKeys<TE>(PairIdComponent key, ISession session)
        {
            if (null == session)
            {
                Logger.Log("Could not create database connection.", LogLevel.ERROR);
                throw new Exception(string.Intern("Could not create database connection."));
            }

            try
            {
                IList<TE> retList = session.CreateCriteria(typeof(TE)).
                    Add(Restrictions.Eq("Id.Key1", key.Key1)).
                    Add(Restrictions.Eq("Id.Key2", key.Key2)).List<TE>();
                return retList;
                // This is how to do the same thing in hql.
                // ----------------------------------------
                //string hql = string.Format("FROM {0} tn WHERE tn.Id.Key1='{1}' AND tn.Id.Key2='{2}'", typeof(E).Name, key.Key1.ToString(), key.Key2.ToString());
                //return (List<E>)session.CreateQuery(hql).List();
            }
            catch (Exception e)
            {
                Logger.Log(string.Format("Error when trying to load Entity {0}.  Message: {1}.",
                                          typeof(TE).Name, e.Message)
                            , LogLevel.ERROR);
                throw;
            }
        }

        /// <summary>
        /// Generic data entity save function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to save.</typeparam>
        /// <param name="entity">The entity to save.</param>
        public static void Save<TE>(TE entity)
        {
            try
            {
                using (ISession session = NhibernateSessionFactory.Instance.GetSession())
                {
                    Save(entity, session);
                }
            }
            catch (Exception e)
            {
                Logger.Log(String.Format("Error getting default session in Load message was: {0}",
                                          e.Message)
                            , LogLevel.ERROR);
                throw;
            }
        }

        /// <summary>
        /// Generic data entity save or update function.
        /// NOTE:  Use the Save method the first time the entity is saved.  It works better.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to save or update.</typeparam>
        /// <param name="entity">The entity to save or update.</param>
        public static void Update<TE>(TE entity)
        {
            try
            {
                using (ISession session = NhibernateSessionFactory.Instance.GetSession())
                {
                    Update(entity, session);
                }
            }
            catch (Exception e)
            {
                Logger.Log(String.Format("Error getting default session in Update message was: {0}",
                                          e.Message)
                            , LogLevel.ERROR);
                throw;
            }
        }

        /// <summary>
        /// Generic data entity delete function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to delete.</typeparam>
        /// <param name="entity">The entity to delete.</param>
        public static void Delete<TE>(TE entity)
        {
            try
            {
                using (ISession session = NhibernateSessionFactory.Instance.GetSession())
                {
                    Delete(entity, session);
                }
            }
            catch (Exception e)
            {
                Logger.Log(String.Format("Error getting default session in Delete message was: {0}",
                                          e.Message)
                            , LogLevel.ERROR);
                throw;
            }
        }

        /// <summary>
        /// Generic data entity delete function.
        /// </summary>
        /// <typeparam name="TE">The type of the entity to delete.</typeparam>
        /// <param name="entity">The entity to delete.</param>
        /// <param name="session">Session to use.</param>
        public static void Delete<TE>(TE entity, ISession session)
        {
            if (null == session)
            {
                Logger.Log("Could not create database connection.", LogLevel.ERROR);
                throw new Exception(string.Intern("Could not create database connection."));
            }

            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Log(string.Format("Error when trying to delete entity {0}.  Message: {1}.",
                                              typeof(TE).Name, ex.Message)
                                , LogLevel.ERROR);
                    throw;
                }
                finally
                {
                    if (null != transaction && transaction.IsActive)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

       public static void DeleteViaSql<TE>(string deleteClause, ISession session)
        {
            if (null == session)
            {
                Logger.Log("Could not create database connection.", LogLevel.ERROR);
                throw new Exception(string.Intern("Could not create database connection."));
            }
            DbConnectionConfigHelper dbConnHelper = new DbConnectionConfigHelper();
            dbConnHelper.LoadConfiguration(GetConfigurationSetting.Instance.GetAppSetting("geoKNXConnectionName"));
            DatabaseObjectsFactory dbObjFactory = dbConnHelper.GetDatabaseObjectsFactory();
            deleteClause = dbObjFactory.TranslateSQL(deleteClause);
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.CreateSQLQuery(deleteClause).UniqueResult();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Log(string.Format("Error when trying to delete entity {0}.  Message: {1}.",
                                              typeof(TE).Name, ex.Message)
                                , LogLevel.ERROR);
                    throw;
                }
                finally
                {
                    if (null != transaction && transaction.IsActive)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
         * 
         */
        #endregion Public Methods
    }
}
