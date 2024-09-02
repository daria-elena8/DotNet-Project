namespace DotnetProjectAPI.Models.DTOs
{
    public class LikeDto
    {
        public Guid Id { get; set; }
        public Guid VisitId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
