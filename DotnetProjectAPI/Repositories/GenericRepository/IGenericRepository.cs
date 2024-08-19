﻿using DotnetProjectAPI.Models.Base;

namespace DotnetProjectAPI.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        // Get all data

        Task<List<TEntity>> GetAll();

        // Create data
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        TEntity FindById(Guid id);
        Task<TEntity> FindByIdAsync(Guid id);

        // Save
        bool Save();
        Task<bool> SaveAsync();

    }
}
