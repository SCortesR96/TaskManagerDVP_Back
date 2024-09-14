﻿namespace TaskManager.Data.Task.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public int? Code { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public bool IsActived { get; set; }
        public int TaskStatusId { get; set; }
        public int AssignedUserId { get; set; }
        public DateTime? ClosedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
