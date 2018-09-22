namespace NewOnlineTheater.Customer.Infrastructure.Repository
{
    using System.Data;
    using System.Linq;
    using NHibernate;
    using Domain.Repository;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        private bool _isAlive = true;

        public UnitOfWork(SessionFactory sessionFactory)
        {
            _session = sessionFactory.OpenSession();
            _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            if (!_isAlive)
                return;

            try
            {
                _transaction.Commit();
            }
            finally
            {
                _isAlive = false;
                _transaction.Dispose();
                _session.Dispose();
            }
        }

        public T Get<T>(long id)
        {
            return _session.Get<T>(id);
        }

        public void SaveOrUpdate<T>(T entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public void Delete<T>(T entity)
        {
            _session.Delete(entity);
        }

        public IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }
    }
}
