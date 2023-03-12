using Microsoft.EntityFrameworkCore;
using VetClinic.DAL;
using VetClinic.Domain.Entity;
using VetClinic.Domain.Entity.ViewModel;
using VetClinic.Domain.Enum;
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

        public async Task CreateVetPassportAsync(VetPassportViewModel viewModel)
        {
            var entity = new VetPassportEntity()
            {
                PetName = viewModel.PetName,
                Breed = viewModel.Breed,
                SpecialSigns = viewModel.SpecialSigns,
                Birthday = viewModel.Birthday,
                MicrochipNumber = viewModel.MicrochipNumber,
                MicrochipDate = viewModel.MicrochipDate,
                LocationOfMicrochip = viewModel.LocationOfMicrochip,
                GenderVariantId = viewModel.GenderVariantId,
                PetOwnerId = viewModel.PetOwnerId
            };

            await _context.VetPassports.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VetPassportEntity>> GetAllAsync()
        {
            return await _context.VetPassports
                .Include(e => e.PetOwner)
                .ToListAsync();
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

        public async Task<IEnumerable<VetPassportEntity>> SelectVetPassportsAsync(long ownerId)
        {
            var entity = await _context.VetPassports
                .Where(e => e.PetOwnerId == ownerId)
                .ToListAsync();

            return entity;
        }
    }
}
