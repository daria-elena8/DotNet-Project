using DotnetProjectAPI.Models.Base;

namespace DotnetProjectAPI.Models
{
    public class Place : BaseEntity
    {
        public string name { get; set; } = default!;
        public string? description { get; set; } = default!;

        // Place - PlaceRating      One-to-One relation
        public PlaceRating placeRating { get; set; }

        // Place - Visit            One-to-Many relation
        // Originated from separating User-Place Many-to-Many relation
        public List<Visit> visits { get; set; } = new List<Visit>();



    }
}
