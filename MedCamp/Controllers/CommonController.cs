using MedCamp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedCamp.Controllers
{
    public class CommonController : Controller
    {
        private readonly MedCampContext _context;
        public CommonController(MedCampContext context)
        {
            _context = context;
        }
        public int GetUserId(HttpRequest httpRequest)
        {
            string accessToken=httpRequest.Cookies["user-access-token"];
            if (accessToken != null)
            {
                User user=_context.Users.Where(x => x.AccessToken.Equals(accessToken)).FirstOrDefault();
                return user.Id;
            }
            return 0;
        }
    }
}
