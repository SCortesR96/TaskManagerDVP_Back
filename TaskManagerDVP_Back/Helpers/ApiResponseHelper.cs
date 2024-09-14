using Microsoft.AspNetCore.Mvc;

namespace TaskManagerDVP_Back.Helpers
{
    public static class ApiResponseHelper
    {
        public static IActionResult JsonResponse<T>(T data, bool success = true, int status = 200)
        {
            var response = new
            {
                success,
                status,
                data,
            };

            return new JsonResult(response);
        }
    }
}
