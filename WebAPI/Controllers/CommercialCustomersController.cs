using Business.Abstract;
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
    public class CommercialCustomersController : ControllerBase
    {
        ICommercialCustomerService _commercialCustomerService;

        public CommercialCustomersController(ICommercialCustomerService commercialCustomerService)
        {
            _commercialCustomerService = commercialCustomerService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(CommercialCustomerDetailDto  commercialCustomerDetailDto)
        {
            var result = await _commercialCustomerService.AddAsync(commercialCustomerDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
