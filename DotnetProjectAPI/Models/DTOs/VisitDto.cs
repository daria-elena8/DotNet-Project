namespace DotnetProjectAPI.Models.DTOs
{
    public class VisitDto
    {
        public Guid Id { get; set; }

        public Guid placeId { get; set; }
        public Guid userId { get; set; }
        public string title { get; set; } = default!;
        public string description { get; set; } = default!;
        public int rating { get; set; } = 0;
    }
}
