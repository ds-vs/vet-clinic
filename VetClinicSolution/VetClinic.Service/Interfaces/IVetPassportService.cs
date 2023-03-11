using VetClinic.Domain.Entity;
using VetClinic.Service.Implementations;

namespace VetClinic.Service.Interfaces
{
    public interface IVetPassportService
    {
        public Task<VetPassportEntity> GetVetPassportAsync(long id);
    }
}
