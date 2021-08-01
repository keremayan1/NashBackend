using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http;

namespace Core.Extensions
{
  public  class WebAPIExceptionFilter:ExceptionFilterAttribute,IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var res = actionExecutedContext.Exception.Message;
            var response = new HttpResponseException(System.Net.HttpStatusCode.InternalServerError)
            {
            };
        }
    }
}
