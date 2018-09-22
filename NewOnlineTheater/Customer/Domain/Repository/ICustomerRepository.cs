namespace NewOnlineTheater.Customer.Domain.Repository
{
    using Entity;
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(Email email);
    }
}
