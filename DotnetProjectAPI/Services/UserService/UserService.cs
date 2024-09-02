using AutoMapper;
using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Models.Enums;
using DotnetProjectAPI.Repositories.UserRepository;
using DotnetProjectAPI.Services.UserService;
using DotnetProjectAPI.Services.GenericService;


namespace DotnetProjectAPI.Services.UserService
{
    public class UserService : GenericService<UserDto, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
            :base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            var user = await _userRepository.FindByUsername(username);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            var user = new User
            {
                id = Guid.NewGuid(),
                username = userDto.Username,
                email = userDto.Email,
                role = userDto.Role,
                password = userDto.Password,
                firstName = userDto.FirstName,
                lastName = userDto.LastName
            };

            await _userRepository.CreateAsync(user);
            await _userRepository.SaveAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _userRepository.FindByUsername(username);

            if (user == null || user.password != password)
            {
                Console.WriteLine("User not found / invalid password");
                return null;
            }

            Console.WriteLine("User found");
            return user;
        }
    }

}
