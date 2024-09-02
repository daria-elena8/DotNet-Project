using System.Linq.Expressions;
using DotnetProjectAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectAPI.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly projectContext _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(projectContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> obj)
        {
            return await _table.AnyAsync(obj);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).AsNoTracking();
        }
    }
}