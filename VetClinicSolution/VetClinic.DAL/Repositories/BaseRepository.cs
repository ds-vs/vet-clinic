using Microsoft.EntityFrameworkCore;

namespace VetClinic.DAL.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;

        public BaseRepository(TContext context) 
        { 
            _context = context;
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity == null)
                return false;

            _context.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            var entity =  await _context.Set<TEntity>().FindAsync(id);

            return entity!;
        }

        public async Task<IEnumerable<TEntity>> SelectAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
