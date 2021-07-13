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
    public class ShopsController : ControllerBase
    {
        IShopService _shopService;

        public ShopsController(IShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpGet("getshop")]
        public IActionResult GetShop()
        {
            var result =  _shopService.GetShops();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(ShopDetailDto shopDetailDto)
        {
            var result = await _shopService.AddAsync(shopDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public async  Task<IActionResult> GetAll()
        {
            var result = await _shopService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
