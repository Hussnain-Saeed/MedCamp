using MedCamp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedCamp.Controllers
{
    public class AccountController : Controller
    {
        private readonly MedCampContext _context;

        public AccountController(MedCampContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            //CookieOptions option = new CookieOptions();
            //option.Expires = DateTime.Now.AddDays(30);
            //Response.Cookies.Append("user-access-token", "123", option);
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            //Response.Cookies.Delete("user-access-token");
            return Redirect("/Home/Index");
        }
    }
}
