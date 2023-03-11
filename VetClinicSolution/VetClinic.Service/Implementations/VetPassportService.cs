using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetClinic.DAL;
using VetClinic.DAL.Repositories;
using VetClinic.Domain.Entity;
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

        public async Task<VetPassportEntity> GetVetPassportAsync(long id)
        {
            var entity = await _context.VetPassports
                .Include(e => e.PetOwner)
                .FirstOrDefaultAsync(e => e.VetPassportId == id);

            if (entity == null)
                throw new NullReferenceException("Ошибка: ветеринарная карта с таким номером не найдена.");

            return entity;
        }
    }
}
