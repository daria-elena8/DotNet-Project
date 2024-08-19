namespace DotnetProjectAPI.Models.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public Guid VisitId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = default!;
        public DateTime Timestamp { get; set; }
    }
}
