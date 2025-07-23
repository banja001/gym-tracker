using BuildingBlocks.Core.UseCases;
using FluentResults;
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

        [HttpGet("byUserId")]
        public ActionResult<IEnumerable<WorkoutDto>> GetByUserId()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");

            if (userIdClaim == null || !long.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized("Invalid or missing user ID claim.");
            }

            var result = _workoutService.GetByUserId(userId);
            return CreateResponse(result);
        }


        [HttpPost]
        public ActionResult<WorkoutDto> CreateWorkout([FromBody] WorkoutDto workoutDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");

            if (userIdClaim == null || !long.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized("Invalid or missing user ID claim.");
            }
            workoutDto.UserId = userId;
            var result = _workoutService.Create(workoutDto);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<WorkoutDto> GetById(int id)
        {
            var result = _workoutService.Get(id);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<WorkoutDto> UpdateWorkout(int id, [FromBody] WorkoutDto workoutDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (workoutDto.Id != id)
                return BadRequest("Workout ID in the path and body must match.");

            var result = _workoutService.Update(workoutDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteWorkout(int id)
        {
            var result = _workoutService.Delete(id);
            return CreateResponse(result);
        }
    }
}
