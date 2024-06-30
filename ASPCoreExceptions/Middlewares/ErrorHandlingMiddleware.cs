using ASPCoreExceptions.Exceptions;

namespace ASPCoreExceptions.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;
        private ILogger<ErrorEventHandler> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorEventHandler> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (InvalidRatingException ex) 
            {
                _logger.LogInformation($"Invalid rating {ex.Rating} userd ID: {ex.UserId}");
                context.Response.Redirect("/ProductRatings/Index");
            }
        }
    }
}
