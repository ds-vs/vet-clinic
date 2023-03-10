using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Entity;

namespace VetClinic.DAL
{
    public class VetClinicDbContext : DbContext
    {
        public DbSet<VetPassportEntity> VetPassports { get; set; }

        public VetClinicDbContext(DbContextOptions<VetClinicDbContext> options) : base(options)
        {

        }
    }
}
