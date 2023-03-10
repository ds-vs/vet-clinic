using Microsoft.AspNetCore.Mvc;
using VetClinic.DAL;

namespace VetClinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly VetClinicDbContext _context;

        public HomeController(VetClinicDbContext context) 
        { 
            _context = context;
        }

        public IActionResult Index() => View();
    }
}
