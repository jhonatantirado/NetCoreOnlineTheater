namespace NewOnlineTheater.Customer.Infrastructure.Repository
{
    using Domain.Entity;
    using Domain.Repository;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IReadOnlyList<T> GetAll()
        {
            return _unitOfWork
                .Query<T>()
                .ToList();
        }

        public T GetById(long id)
        {
            return _unitOfWork.Get<T>(id);
        }

        public void Add(T entity)
        {
            _unitOfWork.SaveOrUpdate(entity);
        }
    }
}
