using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class CustomException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is KeyNotFoundException)
            {
                context.ExceptionHandled = true;
                HttpResponse response = context.HttpContext.Response;
                response.StatusCode = 404;
                response.ContentType = "application/json";
            }
        }
    }
}
