using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeworkOne.Filters;

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
        
        if (token == "user-token")
        {
            if (context.ActionDescriptor.RouteValues["action"] == "CreateProduct" ||
                context.ActionDescriptor.RouteValues["action"] == "UpdateProduct" ||
                context.ActionDescriptor.RouteValues["action"] == "DeleteProduct")
            {
                context.Result = new UnauthorizedResult();
            }
        }
        else if (token == "admin-token")
        {
            return;
        }
        else
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
