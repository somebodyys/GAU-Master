using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Midterm.Filters;

public class BasicAuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrEmpty(authHeader))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var token = authHeader.Replace("Bearer ", string.Empty).Trim();

        switch (token)
        {
            case "user-token":
                if (context.ActionDescriptor.RouteValues["action"] == "Post" ||
                    context.ActionDescriptor.RouteValues["action"] == "Update" ||
                    context.ActionDescriptor.RouteValues["action"] == "Delete")
                {
                    context.Result = new UnauthorizedResult();
                }
                break;
            case "admin-token":
                return;
            default:
                context.Result = new UnauthorizedResult();
                break;
        }
    }
}
