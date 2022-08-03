using MedCamp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedCamp.Controllers
{
    public class AdminController : Controller
    {
        private readonly MedCampContext _context;

        public AdminController(MedCampContext context)
        {
            _context = context;
        }
        [AuthorizeAdmin]
        public IActionResult Index()
        {
            return View();
        }
    }
}
