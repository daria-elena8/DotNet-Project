using DotnetProjectAPI.Models.Base;

namespace DotnetProjectAPI.Models
{
    public class PlaceRating : BaseEntity
    {
        public Guid placeId { get; set; }
        public Guid userId { get; set; }
        public double rating { get; set; } = 0;


        // Place - PlaceRating      One-to-One relation
        public Place place { get; set; } 

        // Originated from separating User-Place Many-to-Many relation
        public List<Visit> visits { get; set; } = new List<Visit>();


    }
}
