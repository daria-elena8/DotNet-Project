using DotnetProjectAPI.Models.DTOs;

namespace DotnetProjectAPI.Services.UserService
{
    public interface IUserService
    {

        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUserByUsername(string username);

    }
}
