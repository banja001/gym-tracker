using BuildingBlocks.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training.API.Dtos;
using Training.API.Public;

namespace Gym_tracker.Controllers
{
    [Route("api/workout")]
    [Authorize]
    public class WorkoutController : BaseApiController
    {
        private readonly IWorkoutService _workoutService;
        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }
        [HttpGet]
        public ActionResult<PagedResult<WorkoutDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _workoutService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }
    }
}
