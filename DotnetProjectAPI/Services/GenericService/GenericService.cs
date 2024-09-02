using AutoMapper;
using DotnetProjectAPI.Repositories.GenericRepository;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace DotnetProjectAPI.Services.GenericService
{
    public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity>
        where TDto : class
        where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<TDto>>(entities);
        }

        public async Task<TDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.CreateAsync(entity);
            await _repository.SaveAsync();
            return _mapper.Map<TDto>(entity);
        }

        public async Task UpdateAsync(Guid id, TDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Entity not found");
                //return 1;

            }
            _mapper.Map(dto, entity);
            _repository.Update(entity);
            await _repository.SaveAsync();
            //return false;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new ArgumentException("Entity not found");

            _repository.Delete(entity);
            await _repository.SaveAsync();
        }

        public async Task<List<TDto>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entities = await _repository.FindByCondition(expression).ToListAsync();
            return _mapper.Map<List<TDto>>(entities);
        }


    }
}
