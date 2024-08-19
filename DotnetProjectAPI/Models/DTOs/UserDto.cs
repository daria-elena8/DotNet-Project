﻿using DotnetProjectAPI.Models.Enums;

namespace DotnetProjectAPI.Models.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Role Role { get; set; }

    }
}
