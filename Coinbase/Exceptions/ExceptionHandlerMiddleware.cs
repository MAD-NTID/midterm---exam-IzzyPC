using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Coinbase.Exceptions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //we want the response to output as json
            context.Response.ContentType = "application/json";
            string errorString = "";
            await context.Response.WriteAsync(errorString);


        }
    }
}