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
    public class PrivateCustomersController : ControllerBase
    {
        IPrivateCustomerService _privateCustomerService;

        public PrivateCustomersController(IPrivateCustomerService privateCustomerService)
        {
            _privateCustomerService = privateCustomerService;
        }
        [HttpPost("add")]
        public async Task<IActionResult>Add(PrivateCustomerDetailDto privateCustomer)
        {
            var result = await _privateCustomerService.Add2(privateCustomer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
