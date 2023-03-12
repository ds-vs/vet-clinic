using VetClinic.Domain.Entity;
using VetClinic.Domain.Entity.ViewModel;
using VetClinic.Service.Implementations;

namespace VetClinic.Service.Interfaces
{
    public interface IVetPassportService
    {
        public Task CreateVetPassportAsync(VetPassportViewModel entity);

        public Task<VetPassportEntity> GetVetPassportAsync(long id);

        public Task<IEnumerable<VetPassportEntity>> SelectVetPassportsAsync(long ownerId);

        public Task<IEnumerable<VetPassportEntity>> GetAllAsync();
    }
}
