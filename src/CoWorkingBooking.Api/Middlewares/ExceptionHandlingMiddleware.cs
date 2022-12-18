using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using CoWorkingBooking.Service.Exceptions;

namespace CoWorkingBooking.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlingMiddleware> logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async ValueTask InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (CoWorkingException ex)
            {
                await HandleException(context, ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                //Log
                logger.LogError(ex.ToString());

                await HandleException(context, 500, ex.Message);
            }
        }

        public async Task HandleException(HttpContext context, int code, string message)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new
            {
                Code = code,
                Message = message
            });
        }
    }
}
