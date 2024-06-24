
using PriceFlex_Backend.Controllers;
using PriceFlex_Backend.Exceptions;

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
            try
            {

                await next.Invoke(context);

            }
            catch (BadRequestException exception) {

                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(exception.Message);


            }
            catch (Exception e)
            {
                Console.WriteLine(444);
                Console.WriteLine(e.Message);
                Console.WriteLine(444);
                _logger.LogError(e.Message);
                context.Response.StatusCode = 500;

                await context.Response.WriteAsync("Something went wrong");

            }
        }
    }
}
