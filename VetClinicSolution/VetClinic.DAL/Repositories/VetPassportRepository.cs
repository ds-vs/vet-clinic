using VetClinic.Domain.Entity;

namespace VetClinic.DAL.Repositories
{
    public class VetPassportRepository : BaseRepository<VetPassportEntity, VetClinicDbContext>
    {
        public VetPassportRepository(VetClinicDbContext context) : base(context)
        {
        }
    }
}
