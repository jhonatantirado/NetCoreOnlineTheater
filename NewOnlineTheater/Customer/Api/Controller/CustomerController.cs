namespace NewOnlineTheater.Customer.Api.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using Application.Dto;
    using Application.Service;

    [Produces("application/json")]
    [Route("api/customers")]
    public class CustomerController: Controller
    {
        private readonly ICustomerApplicationService _customerApplicationService;

        public CustomerController(ICustomerApplicationService customerApplicationService)
        {
            _customerApplicationService = customerApplicationService;
       
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customerApplicationService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerDto item)
        {
            return Ok(_customerApplicationService.Create(item));
        }
    }
}