namespace NewOnlineTheater.Customer.Infrastructure.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Entity;
    using Domain.Repository;

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Customer GetByEmail(Email email)
        {
            return _unitOfWork
                .Query<Customer>()
                .SingleOrDefault(x => x.Email == email.Value);
        }
    }
}
