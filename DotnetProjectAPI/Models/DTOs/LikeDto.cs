namespace DotnetProjectAPI.Models.DTOs
{
    public class LikesDto
    {
        public Guid Id { get; set; }
        public Guid VisitId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
