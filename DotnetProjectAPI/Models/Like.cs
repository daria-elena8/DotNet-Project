using DotnetProjectAPI.Models.Base;

namespace DotnetProjectAPI.Models
{
    public class Like: BaseEntity
    {
        // composed key
        public Guid userId { get; set; }
        public Guid placeId { get; set; }



        // Visit - Like        One-to-Many relation
        public Visit visit { get; set; }

        // User - Like         One-to-Many relation
        public User user { get; set; }


    }
}
