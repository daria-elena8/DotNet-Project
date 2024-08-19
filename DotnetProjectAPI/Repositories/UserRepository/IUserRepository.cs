using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Models;

namespace DotnetProjectAPI.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {

        Task<User> FindByUsername(string username);
        Task<List<User>> FindAll();
        Task<List<User>> FindAllActive();


    }
}
