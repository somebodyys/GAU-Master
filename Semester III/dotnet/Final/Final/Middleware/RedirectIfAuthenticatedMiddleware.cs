using Microsoft.AspNetCore.Http.Extensions;

namespace Final.Middleware;

public class RedirectIfAuthenticatedMiddleware
{
    private readonly RequestDelegate _next;

    public RedirectIfAuthenticatedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var returnUrl = context.Request.GetDisplayUrl();
                
            if (returnUrl.Contains("/Register") || returnUrl.Contains("/Login"))
            {
                context.Response.Redirect("/User/Details");
                return;
            }
        }

        await _next(context);
    }
}