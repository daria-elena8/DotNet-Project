using System.Linq.Expressions;

namespace DotnetProjectAPI.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> obj);
        Task SaveAsync();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

    }
}