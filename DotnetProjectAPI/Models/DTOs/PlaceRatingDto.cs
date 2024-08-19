namespace DotnetProjectAPI.Models.DTOs
{
    public class PlaceRatingDto
    {
        public Guid Id { get; set; }

        public Guid placeId { get; set; }
        public Guid userId { get; set; }
        
        public List<Visit> visits { get; set; }
        public int rating { get; set; } = 0;
    }
}
