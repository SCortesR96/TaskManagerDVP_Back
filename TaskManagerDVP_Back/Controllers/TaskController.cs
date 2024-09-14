using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.Task.Models.DTO;
using TaskManager.Domain.Task.Repository;
using TaskManagerDVP_Back.Helpers;

namespace TaskManager.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var result = await _taskRepository.GetTasks();
            return ApiResponseHelper.JsonResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] StoreTaskDTO task)
        {
            try
            {
                var result = await _taskRepository.CreateTask(task);
                return ApiResponseHelper.JsonResponse(result);
            }
            catch (Exception ex)
            {
                return ApiResponseHelper.JsonResponse(ex.Message, false, 500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskDTO task, int id)
        {
            try
            {
                var result = await _taskRepository.UpdateTask(task, id);
                return ApiResponseHelper.JsonResponse(result);
            }
            catch (Exception ex)
            {
                return ApiResponseHelper.JsonResponse(ex.Message, false, 500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var result = await _taskRepository.DeleteTask(id);
                return ApiResponseHelper.JsonResponse(result);
            }
            catch (Exception ex)
            {
                return ApiResponseHelper.JsonResponse(ex.Message, false, 500);
            }
        }
    }
}
