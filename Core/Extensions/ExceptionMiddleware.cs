using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {

                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal Server Error";
            FluentValidationValidationExceptionMessage(exception, ref message);
            SystemAuthenticationExceptionMessage(ref message, exception);
            return httpContext.Response.WriteAsync(new ErrorDetail
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
        private void FluentValidationValidationExceptionMessage(Exception exception, ref string message)
        {
            if (exception.GetType() == typeof(FluentValidation.ValidationException))
            {
                message = exception.Message;
            }
        }
        private void SystemAuthenticationExceptionMessage(ref string message, Exception exception)
        {
            if (exception.GetType() == typeof(AuthenticationException))
            {
                message = exception.Message;
            }
        }
    }
}
