using Microsoft.EntityFrameworkCore;
using VetClinic.DAL;
using VetClinic.Domain.Entity;
using VetClinic.Service.Interfaces;

namespace VetClinic.Service.Implementations
{
    public class VetPassportService : IVetPassportService
    {
        private readonly VetClinicDbContext _context;

        public VetPassportService(VetClinicDbContext context) 
        {
            _context = context;
        }

        public async Task<VetPassportEntity> GetVetPassportAsync(long id)
        {
            var entity = await _context.VetPassports
                .Include(e => e.PetOwner)
                .FirstOrDefaultAsync(e => e.VetPassportId == id);

            if (entity == null)
                throw new NullReferenceException("Ошибка: ветеринарная карта с таким номером не найдена.");

            return entity;
        }

        public async Task<IEnumerable<VetPassportEntity>> SelectVetPassportsAsync()
        {
            var entity = await _context.VetPassports.Include(e => e.PetOwner).ToListAsync();

            return entity;
        }
    }
}
