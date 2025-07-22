using BuildingBlocks.Core.UseCases;
using Members.API.Dtos;
using Members.API.Public;
using Microsoft.AspNetCore.Mvc;
using Training.API.Dtos;
using Training.API.Public;

namespace Gym_tracker.Controllers
{
    [Route("api/user")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<PagedResult<UserDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _userService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }
    }
}
