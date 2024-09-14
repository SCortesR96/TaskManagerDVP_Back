using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Task.Models.DTO
{
    public class StoreTaskDTO
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public int TaskStatusId { get; set; }
        [Required]
        public int AssignedUserId { get; set; }
    }
}
