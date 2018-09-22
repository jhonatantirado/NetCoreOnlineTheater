namespace NewOnlineTheater.Customer.Domain.Repository
{
    using System.Collections.Generic;

    public interface IRepository<T>  where T : class
    {
        IReadOnlyList<T> GetAll();
        T GetById(long id);
        void Add(T entity);
    }
}
