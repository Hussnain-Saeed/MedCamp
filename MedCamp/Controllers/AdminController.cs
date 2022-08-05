using MedCamp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MedCamp.Controllers
{
   [AuthorizeAdmin]
    public class AdminController : Controller
    {
        private readonly MedCampContext _context;

        public AdminController(MedCampContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> DoctorProfiles()
        {
            return View(await _context.DoctorDetails.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> CreateUpdateDoctorProfile(int? id)
        {
            ViewBag.Doctors = new SelectList(_context.Users.Where(x => x.RoleId == 2).ToList(), "Id", "FirstName");
            if (id == null)
                return View();
            else
                return View(await _context.DoctorDetails.Where(d => d.Id == id).FirstOrDefaultAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdateDoctorProfile(DoctorDetail doctorDetail)
        {
            _context.DoctorDetails.Update(doctorDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction("DoctorProfiles");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteDoctorProfile(int? id)
        {
            _context.DoctorDetails.Remove(_context.DoctorDetails.Find(id));
            await _context.SaveChangesAsync();
            return RedirectToAction("DoctorProfiles");
        }
    }
}
