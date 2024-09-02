using DotnetProjectAPI.Models.Base;

namespace DotnetProjectAPI.Models
{
    public class Comment : BaseEntity
    {
        // composed key
        public Guid userId { get; set; }
        public Guid placeId { get; set; }

        public string content { get; set; } = default!;
        public DateTime timestamp { get; set; }

        // User - Comment      One-to-Many relation
        public User user { get; set; }

        // Comment - Visit     One-to-Many relation
        public Visit visit { get; set; }

    }
}
