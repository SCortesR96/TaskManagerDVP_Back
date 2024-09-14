using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Context;
using TaskManager.Domain.User.Models.DTO;
using TaskManager.Domain.User.Repositories;
using TaskManagerDVP_Back.Helpers;

namespace TaskManagerDVP_Back.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var result = await _usersRepository.GetUsers();
                return ApiResponseHelper.JsonResponse(result, true, 201);
            }
            catch (Exception ex)
            {
                return ApiResponseHelper.JsonResponse(ex.Message, false, 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] StoreUserDTO user)
        {
            try
            {
                var result = await _usersRepository.CreateUser(user);
                return ApiResponseHelper.JsonResponse(result);
            }
            catch (Exception ex)
            {
                return ApiResponseHelper.JsonResponse(ex.Message, false, 500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO user, int id)
        {
            try
            {
                var result = await _usersRepository.UpdateUser(user, id);
                return ApiResponseHelper.JsonResponse(result);
            }
            catch (Exception ex)
            {
                return ApiResponseHelper.JsonResponse(ex.Message, false, 500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await _usersRepository.DeleteUser(id);
                return ApiResponseHelper.JsonResponse(result);
            }
            catch (Exception ex)
            {
                return ApiResponseHelper.JsonResponse(ex.Message, false, 500);
            }
        }
    }
}
