using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApplicationServices.CloseFriends;

namespace APICloseFriends.Controllers
{
    [Route("api/CloseFriends")]
    public class CloseFriendsController : Controller
    {
        [Authorize("Bearer")]
        [HttpGet("GetFriends/{x}/{y}")]
        public IActionResult Get(int x, int y, [FromServices]ICloseFriendsService closeFriendsService)
        {
            try
            {
                return new ObjectResult(closeFriendsService.GetFriends(x, y));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(new
                {
                    message = "Ocorreu alguma excessão",
                    exception = ex.Message
                });
            }
        }
    }
}