using Core.Utilities.ReCaptcha;

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
    public class CaptchaController : ControllerBase
    {
      public readonly  IRecaptchaValidator _recaptchaValidator;

        public CaptchaController(IRecaptchaValidator recaptchaValidator)
        {
            _recaptchaValidator = recaptchaValidator;
        }
        [HttpPost]
        public IActionResult OnPostSubscribeNewsletter( string token)
        {
            if (_recaptchaValidator.IsRecaptchaValid(token))
            {
                //return error message or something
                return BadRequest();
            }
            return Ok();
        }
        //public JsonResult OnGetRecaptchaVerify(string token)
        //{
        //    return new JsonResult(_recaptchaValidator.IsRecaptchaValid(token));
        //}
    }
}
