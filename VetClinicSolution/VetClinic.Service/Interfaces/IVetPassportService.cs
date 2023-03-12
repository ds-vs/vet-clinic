using VetClinic.Domain.Entity;
using VetClinic.Domain.ViewModel;

namespace VetClinic.Service.Interfaces
{
    public interface IVetPassportService
    {
        public Task CreateVetPassportAsync(CreateVetPassportViewModel entity);

        public Task<VetPassportEntity> GetVetPassportAsync(long id);

        public Task<IEnumerable<VetPassportEntity>> SelectVetPassportsAsync(long ownerId);

        public Task<IEnumerable<VetPassportEntity>> GetAllAsync();

        public Task<UpdateVetPassportViewModel> ViewAsync(long id);

        public Task EditAsync(UpdateVetPassportViewModel viewModel);

        public Task DeleteAsync(long id);
    }
}
