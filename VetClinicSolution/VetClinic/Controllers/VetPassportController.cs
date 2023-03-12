using Microsoft.AspNetCore.Mvc;
using VetClinic.Domain.Entity;
using VetClinic.Service.Interfaces;

namespace VetClinic.Controllers
{
    public class VetPassportController : Controller
    {
        private readonly IVetPassportService _vetPassportService;

        public VetPassportController(IVetPassportService vetPassportService)
        {
            _vetPassportService = vetPassportService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetAsync(long id)
        {
            var entity = await _vetPassportService.GetVetPassportAsync(id);

            return View(entity);
        }

        public async Task<ActionResult<IEnumerable<VetPassportEntity>>> SelectAsync(long id)
        {
            var entity = await _vetPassportService.SelectVetPassportsAsync(id);

            return View(entity);
        }
    }
}
