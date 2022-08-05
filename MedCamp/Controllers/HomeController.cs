using MedCamp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using MedCamp.Models.ViewModels;

namespace MedCamp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MedCampContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(MedCampContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() // List of Doctor Profiles
        {
            return View(await _context.DoctorDetails
                .Include(model => model.Doctor)
                .Select(x=> 
                new DoctorInfoViewModel {
                    Id=x.Id,
                    Fee=x.Fee,
                    Image=x.Image,
                    Name=$"Dr. {x.Doctor.FirstName} {x.Doctor.LastName}",
                    Speciality=_context.DoctorSpecialities
                                .Include(y=>y.Speciality)
                                .Where(y=>y.DoctorId==x.DoctorId)
                                .Select(y=>y.Speciality.Name)
                                .ToList() 
                }).ToListAsync());
        }
        public async Task<IActionResult> Doctor(int id) // Doctor Profile
        {
            return View(await _context.DoctorDetails.Include(model => model.Doctor).Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}