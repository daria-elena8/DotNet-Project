using DotnetProjectAPI.Models.Base;

namespace DotnetProjectAPI.Models
{
    public class Like: BaseEntity
    {
        public Guid visitId { get; set; }
        public Guid userId { get; set; }
        public DateTime timestamp { get; set; }

        // Visit - Like        One-to-Many relation
        public Visit visit { get; set; }

        // User - Like         One-to-Many relation
        public User user { get; set; }

    }
}
