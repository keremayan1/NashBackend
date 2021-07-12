using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(CustomerDetailDto customerDetailDto)
        {
            var result = await _customerService.AddAsync(customerDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcustomer")]
        public IActionResult GetProductDetail(Customer customer)
        {
            var result = _customerService.GetCustomers(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
