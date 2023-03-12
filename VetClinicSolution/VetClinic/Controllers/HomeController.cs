using Microsoft.AspNetCore.Mvc;
using VetClinic.DAL;
using VetClinic.Domain.Entity;
using VetClinic.Service.Interfaces;

namespace VetClinic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
