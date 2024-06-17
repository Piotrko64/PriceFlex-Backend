﻿
using PriceFlex_Backend.Controllers;

namespace PriceFlex_Backend.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware

    {

           private readonly ILogger _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try { 
            
            await next.Invoke(context);

            }
            catch(Exception e) {

                _logger.LogError(e.Message);
                context.Response.StatusCode = 500;

                await context.Response.WriteAsync("Something went wrong");
            
            }
        }
    }
}
