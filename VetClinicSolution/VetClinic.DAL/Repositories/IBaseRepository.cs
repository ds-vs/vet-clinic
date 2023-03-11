namespace VetClinic.DAL.Repositories
{
    interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> CreateAsync(T entity);
        Task<bool> DeleteAsync(long id);
    }
}
