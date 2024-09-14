using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Task.Models.DTO
{
    public class UpdateTaskDTO
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public int TaskStatusId { get; set; }
        [Required]
        public int AssignedUserId { get; set; }
        [Required]
        public bool IsActived { get; set; }
    }
}
