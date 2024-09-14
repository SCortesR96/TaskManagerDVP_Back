using TaskManager.Domain.Task.Models.DTO;

namespace TaskManager.Domain.Task.Repository
{
    public interface ITaskRepository
    {
        public Task<List<ShowTaskDTO>> GetTasks();
        public Task<ShowTaskDTO> CreateTask(StoreTaskDTO task);
        public Task<ShowTaskDTO> UpdateTask(UpdateTaskDTO task, int id);
        public Task<bool> DeleteTask(int id);
    }
}
