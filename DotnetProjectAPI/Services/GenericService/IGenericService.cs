using AutoMapper;
using DotnetProjectAPI.Repositories.GenericRepository;
using System.Linq.Expressions;

namespace DotnetProjectAPI.Services.GenericService
{
    public interface IGenericService<TDto, TEntity>
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(Guid id);
        Task<TDto> CreateAsync(TDto dto);
        Task UpdateAsync(Guid id, TDto dto);
        Task DeleteAsync(Guid id);
        Task<List<TDto>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression);

    }

}
