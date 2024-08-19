using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectAPI.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(projectContext context) : base(context) { }

        public async Task<List<User>> FindAll()
        {
            return await _table.ToListAsync();        
        }

        public async Task<List<User>> FindAllActive()
        {
            return await _table.GetActiveUsers().ToListAsync();
        }

        public async Task<User> FindByUsername(string username)
        {
            return (await _table.FirstOrDefaultAsync(u => u.Username.Equals(username)))!;
        }
    }




}
