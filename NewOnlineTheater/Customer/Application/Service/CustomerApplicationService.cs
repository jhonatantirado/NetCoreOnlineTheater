namespace NewOnlineTheater.Customer.Application.Service
{
    using Domain.Repository;
    using System.Collections.Generic;
    using Dto;
    using System;
    using CSharpFunctionalExtensions;
    using Domain.Entity;
    using AutoMapper;

    public class CustomerApplicationService: ICustomerApplicationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        public CustomerApplicationService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public List<CustomerInListDto> GetAll()
        {
          return Mapper.Map<List<CustomerInListDto>>(_customerRepository.GetAll());
        }

        public int Create(CreateCustomerDto item)
        {
            Result<CustomerName> customerNameOrError = CustomerName.Create(item.Name);
            Result<Email> emailOrError = Email.Create(item.Email);

            Result result = Result.Combine(customerNameOrError, emailOrError);
            if (result.IsFailure)
                 throw new ArgumentException(result.Error);

            if (_customerRepository.GetByEmail(emailOrError.Value) != null)
                 throw new ArgumentException("Email is already in use: " + item.Email);

            var customer = new Customer(customerNameOrError.Value, emailOrError.Value);
            _customerRepository.Add(customer);
           _unitOfWork.Commit();
            return customer.Id;

        }
    }
}
