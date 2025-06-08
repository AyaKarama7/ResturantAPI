
using Resturant.Domain.Exceptions;

namespace Resturant.API.Middlewarea
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(NotFoundException)
            {
                logger.LogInformation("Resource not found.");
                context.Response.StatusCode = 404; // Not Found
                await context.Response.WriteAsync("Resource not found");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unhandled exception occurred while processing the request.");
                context.Response.StatusCode = 500; // Internal Server Error
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
