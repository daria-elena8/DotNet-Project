﻿using AutoMapper;
using DotnetProjectAPI.Models.DTOs;
using DotnetProjectAPI.Repositories.UserRepository;
using DotnetProjectAPI.Services.UserService;

namespace DotnetProjectAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.FindAll();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            var user = await _userRepository.FindByUsername(username);

            //        var userDto = new UserDto
            //        {
            //            Username = user.Username,
            //            FullName = user.LastName + ' ' + user.FirstName,
            //            Email = user.Email,
            //            Id = user.Id
            //        };

            return _mapper.Map<UserDto>(user);
        }
    }
}
