using MedCamp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedCamp.Controllers
{
    public class ConsultationController : Controller
    {
        private readonly MedCampContext _context;
        public ConsultationController(MedCampContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            ViewBag.OrderId=id;
            return View(_context.Messages.Where(x=>x.ConsultationId==id).Include(x=>x.Sender).OrderByDescending(x=>x.Id).ToList());
        }
    }
}
