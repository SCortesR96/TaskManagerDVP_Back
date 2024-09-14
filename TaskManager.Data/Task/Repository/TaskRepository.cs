using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Context;
using TaskManager.Data.Task.Entities;
using TaskManager.Domain.Task.Models.DTO;
using TaskManager.Domain.Task.Repository;

namespace TaskManager.Data.Task.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShowTaskDTO>> GetTasks()
        {
            var result = await _context.tasks.Where(x => x.IsActived == true).ToListAsync();
            return result.Adapt<List<ShowTaskDTO>>();
        }

        public async Task<ShowTaskDTO> CreateTask(StoreTaskDTO task)
        {
            var rand = new Random();
            var code = rand.NextInt64(6);

            TaskEntity taskAdapt = task.Adapt<TaskEntity>();
            taskAdapt.Code = rand.Next(100000, 999999);
            taskAdapt.IsActived = true;
            taskAdapt.CreatedAt = DateTime.Now;
            taskAdapt.CreatedBy = "scortesr";

            _context.tasks.Add(taskAdapt);
            var result = await _context.SaveChangesAsync();

            return taskAdapt.Adapt<ShowTaskDTO>();
        }

        public async Task<ShowTaskDTO> UpdateTask(UpdateTaskDTO task, int id)
        {
            var taskEntity = await _context.tasks.Where(x => x.Id == id).FirstOrDefaultAsync();

            taskEntity.Title = task.Title;
            taskEntity.Description = task.Description;
            taskEntity.IsActived = task.IsActived;
            taskEntity.TaskStatusId = task.TaskStatusId;
            taskEntity.AssignedUserId = task.AssignedUserId;
            taskEntity.UpdatedAt = DateTime.Now;
            taskEntity.UpdatedBy = "scortesr";

            _context.tasks.Update(taskEntity);
            var result = await _context.SaveChangesAsync();

            return taskEntity.Adapt<ShowTaskDTO>();
        }

        public async Task<bool> DeleteTask(int id)
        {
            var taskEntity = await _context.tasks.Where(x => x.Id == id).FirstOrDefaultAsync();

            taskEntity.IsActived = false;

            _context.tasks.Update(taskEntity);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
