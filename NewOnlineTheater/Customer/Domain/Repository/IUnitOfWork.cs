namespace NewOnlineTheater.Customer.Domain.Repository
{
    using System.Linq;

    public interface IUnitOfWork
    {
        void Commit();
        T Get<T>(long id);
        void SaveOrUpdate<T>(T entity);
        void Delete<T>(T entity);

        IQueryable<T> Query<T>();

    }
}
