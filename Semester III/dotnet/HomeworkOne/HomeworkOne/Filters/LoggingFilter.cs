using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeworkOne.Filters;

public class LoggingFilter : ActionFilterAttribute
{
    private readonly ILogger<LoggingFilter> _logger;
    private Stopwatch _stopwatch;

    public LoggingFilter(ILogger<LoggingFilter> logger)
    {
        _logger = logger;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch = Stopwatch.StartNew();

        var actionName = context.ActionDescriptor.DisplayName;
        var httpMethod = context.HttpContext.Request.Method;
        var routeData = string.Join(", ", context.RouteData.Values.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        var queryParams = string.Join(", ", context.HttpContext.Request.Query.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        
        _logger.LogInformation("Starting execution of action: {ActionName}", actionName);
        _logger.LogInformation("HTTP Method: {HttpMethod}", httpMethod);
        _logger.LogInformation("Route Data: {RouteData}", routeData);
        
        if (!string.IsNullOrEmpty(queryParams))
        {
            _logger.LogInformation("Query Parameters: {QueryParams}", queryParams);
        }

        if (httpMethod == "POST" || httpMethod == "PUT")
        {
            var requestBody = JsonSerializer.Serialize(context.ActionArguments);
            _logger.LogInformation("Request Body: {RequestBody}", requestBody);
        }

        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();

        var actionName = context.ActionDescriptor.DisplayName;
        var executionTime = _stopwatch.ElapsedMilliseconds;
        var statusCode = context.HttpContext.Response.StatusCode;
        
        _logger.LogInformation("Finished execution of action: {ActionName}", actionName);
        _logger.LogInformation("Execution Time: {ExecutionTime} ms", executionTime);
        _logger.LogInformation("Response Status Code: {StatusCode}", statusCode);

        base.OnActionExecuted(context);
    }
}