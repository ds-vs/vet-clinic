using Microsoft.EntityFrameworkCore;
using VetClinic.DAL;
using VetClinic.Domain.Entity;
using VetClinic.Domain.Enum;
using VetClinic.Domain.ViewModel;
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

        public async Task CreateVetPassportAsync(CreateVetPassportViewModel viewModel)
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

        public async Task<UpdateVetPassportViewModel> ViewAsync(long id)
        {
            var entity = await _context.VetPassports.FirstOrDefaultAsync(e => e.VetPassportId == id);

            if (entity == null)
                throw new NullReferenceException("Ошибка: ветеринарная карта с таким номером не найдена.");

            var viewModel = new UpdateVetPassportViewModel()
            {
                VetPassportId = entity.VetPassportId,
                PetName = entity.PetName,
                Breed = entity.Breed,
                SpecialSigns = entity.SpecialSigns,
                Birthday = entity.Birthday,
                MicrochipNumber = entity.MicrochipNumber,
                MicrochipDate = entity.MicrochipDate,
                LocationOfMicrochip = entity.LocationOfMicrochip,
                GenderVariantId = entity.GenderVariantId,
                PetOwnerId = entity.PetOwnerId
            };

            return viewModel;
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

        public async Task EditAsync(UpdateVetPassportViewModel viewModel)
        {
            var entity = await _context.VetPassports.FindAsync(viewModel.VetPassportId);

            if (entity == null)
                throw new NullReferenceException("Ошибка: ветеринарная карта с таким номером не найдена.");

            entity.PetName = viewModel.PetName;
            entity.Breed = viewModel.Breed;
            entity.SpecialSigns = viewModel.SpecialSigns;
            entity.Birthday = viewModel.Birthday;
            entity.MicrochipNumber = viewModel.MicrochipNumber;
            entity.MicrochipDate = viewModel.MicrochipDate;
            entity.LocationOfMicrochip = viewModel.LocationOfMicrochip;
            entity.GenderVariantId = viewModel.GenderVariantId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.VetPassports.FindAsync(id);

            if (entity != null)
            {
                _context.VetPassports.Remove(entity);

                await _context.SaveChangesAsync();
            }
        }
    }
}
