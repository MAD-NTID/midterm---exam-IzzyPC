using System;
using System.Text.Json;
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

        //Probably this is a good place to get the header info
        public async Task InvokeAsync(HttpContext context)
        {
            // string authHeader = context.Request.Headers["Authorization"];
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string errorMsg = "An internal error occurred while processing your request. Please try again later.";
            int statusCode = 500;
            
            if (exception is IUserErrorException)
            {
                UserErrorException err = (UserErrorException) exception;
                statusCode = err.GetStatusCode();
                errorMsg = err.GetMessage();                
            }
            //we want the response to output as json
            context.Response.ContentType = "application/json";
            string errorString = JsonSerializer.Serialize(new {Message = errorMsg, StatusCode = statusCode});
            await context.Response.WriteAsync(errorString);


        }
    }
}