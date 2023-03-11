using Microsoft.AspNetCore.Mvc;
using VetClinic.DAL;
using VetClinic.DAL.Repositories;
using VetClinic.Domain.Entity;

namespace VetClinic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
