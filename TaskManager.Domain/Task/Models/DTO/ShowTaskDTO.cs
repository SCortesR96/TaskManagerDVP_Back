namespace TaskManager.Domain.Task.Models.DTO
{
    public class ShowTaskDTO
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsActived { get; set; }
        public int TaskStatusId { get; set; }
        public int AssignedUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ClosedAt { get; set; }
    }
}
