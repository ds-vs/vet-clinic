using Microsoft.AspNetCore.Mvc;
using VetClinic.DAL;
using VetClinic.DAL.Repositories;
using VetClinic.Domain.Entity;
using VetClinic.Service.Interfaces;

namespace VetClinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVetPassportService _vetPassportService;

        public HomeController(IVetPassportService vetPassportService)
        {
            _vetPassportService = vetPassportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetVetPassportAsync(long id)
        {
            var entity = await _vetPassportService.GetVetPassportAsync(id);

            return View(entity);
        }
    }
}
