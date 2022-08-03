using MedCamp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MedCamp
{
    public class AuthorizeAdminAttribute:Attribute,IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string httpCookie = context.HttpContext.Request.Cookies["user-access-token"];
            //get your dbcontext
            var db = context.HttpContext.RequestServices.GetRequiredService<MedCampContext>();
            if (httpCookie != null)
            {
                if (!db.Users.Where(x => x.AccessToken.Equals(httpCookie) && x.Role.Name.Equals("Admin")).Any())
                    context.Result = new RedirectToRouteResult("/Account/Login");
            }
            else
                context.Result = new RedirectResult("/Account/Login");

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

    }
}
