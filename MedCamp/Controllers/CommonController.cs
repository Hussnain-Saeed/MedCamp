using MedCamp.Models;
using MedCamp.Models.ViewModels;
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
        public UserInfoViewModel GetUserInfo(HttpRequest httpRequest)
        {
            string accessToken = httpRequest.Cookies["user-access-token"];
            if (accessToken != null)
            {
                var user = _context.Users.Where(x => x.AccessToken.Equals(accessToken)).FirstOrDefault();
                if (user != null)
                    return new UserInfoViewModel { Id = user.Id, Name = $"{user.FirstName} {user.LastName}" };
            }
            return new UserInfoViewModel();
        }
    }
}
