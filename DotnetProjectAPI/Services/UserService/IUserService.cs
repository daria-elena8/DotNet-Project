using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Services.GenericService;

namespace DotnetProjectAPI.Services.UserService
{
    public interface IUserService : IGenericService<UserDto, User>
    { 
        Task<UserDto> GetUserByUsername(string username);
       
    }
}
