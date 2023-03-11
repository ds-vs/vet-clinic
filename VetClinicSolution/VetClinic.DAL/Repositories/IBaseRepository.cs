namespace VetClinic.DAL.Repositories
{
    interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> SelectAsync();
        Task<T> GetByIdAsync(long id);
        Task<bool> CreateAsync(T entity);
        Task<bool> DeleteAsync(long id);
    }
}
