using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using NHibernate;
using NHibernate.Linq;

namespace WebAPI.Repositories
{
    public class Repository : IRepository
    {
        #region properties

        private ISession session;

        #endregion

        #region private methods

        // Constructor
        public Repository(ISession _session)
        {
            session = _session;
        }

        private void Refresh()
        {
            if (!session.IsOpen)
            {
                session.Reconnect();
            }
        }
        #endregion

        #region Implemented Methods

        public T Get<T>(object id) where T : class
        {
            Refresh();
            return session.Get<T>(id);
        }

        public IList<T> GetAll<T>() where T : class
        {
            Refresh();
            return session.Query<T>().ToList();
        }

        public IList<T> Where<T>(Expression<Func<T, bool>> condition) where T : class
        {
            Refresh();
            return session.Query<T>().Where(condition).ToList();
        }

        public IList<T> Where<T>(Expression<Func<T, bool>> condition, int quantity) where T : class
        {
            Refresh();
            return session.Query<T>().Where(condition).Take(quantity).ToList();
        }

        public void Insert<T>(T obj) where T : class
        {
            Refresh();

            try
            {
                session.Save(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete<T>(T obj) where T : class
        {
            Refresh();
            try
            {
                session.Delete(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete<T>(Expression<Func<T, bool>> condition)
        {
            Refresh();
            session.Query<T>().Where(condition).Delete();
        }

        public void Commit()
        {
            Refresh();
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Flush();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
            session.Clear();
        }

        public void Clear()
        {
            Refresh();
            session.Clear();
        }

        public void Close()
        {
            session.Close();
            Dispose();
        }
        public void Dispose()
        {
            session?.Dispose();
        }

        #endregion
    }
}