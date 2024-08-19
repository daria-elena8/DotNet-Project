namespace DotnetProjectAPI.Models.DTOs
{
    public class PlaceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public PlaceRating placeRating { get; set; }
        public List<Visit> visits { get; set; }

    }
}
