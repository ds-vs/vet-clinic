using Microsoft.AspNetCore.Mvc;
using VetClinic.Domain.Entity;
using VetClinic.Domain.ViewModel;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VetPassportEntity>>> Index()
        {
            var entities = await _vetPassportService.GetAllAsync();

            return View(entities);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateVetPassportViewModel addVetPassportRequest)
        {
            await _vetPassportService.CreateVetPassportAsync(addVetPassportRequest);

            return RedirectToAction(nameof(Create));
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync(long id)
        {
            var entity = await _vetPassportService.GetVetPassportAsync(id);

            return View(entity);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(long id)
        {
            var entity = await _vetPassportService.ViewAsync(id);

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(UpdateVetPassportViewModel updateVetPassportRequest)
        {
            await _vetPassportService.EditAsync(updateVetPassportRequest);

            return RedirectToAction("Get", new { id = updateVetPassportRequest.VetPassportId });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VetPassportEntity>>> SelectAsync(long id)
        {
            var entity = await _vetPassportService.SelectVetPassportsAsync(id);

            return View(entity);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            await _vetPassportService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
