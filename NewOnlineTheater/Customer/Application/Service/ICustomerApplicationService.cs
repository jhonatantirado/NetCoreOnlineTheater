namespace NewOnlineTheater.Customer.Application.Service
{
    using System.Collections.Generic;
    using Dto;

    public interface ICustomerApplicationService
    {
        List<CustomerInListDto> GetAll();

        int Create(CreateCustomerDto item);
    }
}
