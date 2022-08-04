using MedCamp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MedCamp
{
    public class AuthorizeAdminAttribute:Attribute,IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string accessToken = context.HttpContext.Request.Cookies["user-access-token"];
            if (!string.IsNullOrEmpty(accessToken))
            {
                var db = context.HttpContext.RequestServices.GetRequiredService<MedCampContext>();
                if (!db.Users.Where(x => x.AccessToken.Equals(accessToken) && x.Role.Name.Equals("Admin")).Any())
                    context.Result = new RedirectResult("/Account/Login");
            }
            else
                context.Result = new RedirectResult("/Account/Login");

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

    }
}
