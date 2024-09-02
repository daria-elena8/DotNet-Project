using DotnetProjectAPI.Models.Base;
using DotnetProjectAPI.Models.Enums;

namespace DotnetProjectAPI.Models
{
    public class User : BaseEntity
    {
        public string firstName { get; set; } = default!;
        public string lastName { get; set; } = default!;
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Role role { get; set; }


        // User - Visit        One-to-Many relation
        // Originated from separating User-Place Many-to-Many relation
        public List<Visit> visits { get; set; } = new List<Visit>();

        // User - Like         One-to-Many relation
        public List<Like> likes { get; set; } = new List<Like>();

        // User - Comment      One-to-Many relation
        public List<Comment> comments { get; set; } = new List<Comment>();

    }
}
