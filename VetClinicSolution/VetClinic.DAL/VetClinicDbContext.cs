using Microsoft.EntityFrameworkCore;

namespace VetClinic.DAL
{
    public class VetClinicDbContext : DbContext
    {
        public VetClinicDbContext(DbContextOptions<VetClinicDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
