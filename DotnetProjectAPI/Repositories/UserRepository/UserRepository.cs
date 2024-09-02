using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Data;
using DotnetProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectAPI.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(projectContext context) : base(context) { }

        public async Task<User> FindByUsername(string username)
        {
            return (await _table.FirstOrDefaultAsync(u => u.username.Equals(username)))!;
        }
        public async Task<User> FindById(Guid id)
        {
            return (await _table.FirstOrDefaultAsync(i => i.id.Equals(id)))!;
        }
    }




}
