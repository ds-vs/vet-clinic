using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Entity;

namespace VetClinic.DAL
{
    public class VetClinicDbContext : DbContext
    {
        DbSet<VetPassportEntity>

        public VetClinicDbContext(DbContextOptions<VetClinicDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
