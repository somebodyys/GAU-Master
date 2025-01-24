using Microsoft.AspNetCore.Mvc.Filters;

namespace Final.Filters;

public class RequestResponseLoggingFilter : IAsyncActionFilter
{
    private readonly ILogger<RequestResponseLoggingFilter> _logger;

    public RequestResponseLoggingFilter(ILogger<RequestResponseLoggingFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var request = context.HttpContext.Request;
        _logger.LogInformation("Incoming request: {method} {url}", request.Method, request.Path);
        
        var resultContext = await next();

        var response = resultContext.HttpContext.Response;
        _logger.LogInformation("Outgoing response: {statusCode}", response.StatusCode);
    }
}