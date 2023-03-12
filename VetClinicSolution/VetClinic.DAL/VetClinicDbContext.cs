using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Entity;
using VetClinic.Domain.Enum;

namespace VetClinic.DAL
{
    public class VetClinicDbContext : DbContext
    {
        public DbSet<VetPassportEntity> VetPassports { get; set; }
        public DbSet<PetOwnerEntity> PetOwners { get; set; }

        public VetClinicDbContext(DbContextOptions<VetClinicDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<VetPassportEntity>()
                .Property(e => e.GenderVariantId)
                .HasConversion<int>();

            modelBuilder
                .Entity<GenderVariant>()
                .Property(e => e.GenderVariantId)
                .HasConversion<int>();

            modelBuilder
                .Entity<GenderVariant>()
                .HasData(Enum.GetValues(typeof(GenderVariantId))
                .Cast<GenderVariantId>()
                .Select(e => new GenderVariant()
                {
                    GenderVariantId = e,
                    Name = e.ToString(),
                })
            );
        }
    }
}
