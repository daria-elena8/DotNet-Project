using DotnetProjectAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;


namespace DotnetProjectAPI.Models.DTOs
{
    public class UserDto
    {
        //public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;

        [Required]
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }
        public string Password { get; set; } = default!;

        public string? FirstName { get; set; } = default!;
        public string? LastName { get; set; } = default!;
    }
}
