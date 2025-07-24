using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training.API.Dtos;
using Training.API.Public;

namespace Gym_tracker.Controllers.Workout
{
    [Route("api/workout-statistics")]
    [Authorize]
    public class WorkoutStatisticsController:BaseApiController
    {
        private readonly IWorkoutStatisticsService _workoutStatisticsService;
        public WorkoutStatisticsController(IWorkoutStatisticsService workoutStatisticsService)
        {
            _workoutStatisticsService = workoutStatisticsService;
        }

        [HttpGet("weekly")]
        public ActionResult<IEnumerable<WeeklyWorkoutStatsDto>> GetWeeklyStatistics([FromQuery] int year, [FromQuery] int month)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");

            if (userIdClaim == null || !long.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized("Invalid or missing user ID claim.");
            }

            var result = _workoutStatisticsService.GetWeeklyStats(year, month, userId);
            return Ok(result.Value);
        }
    }
}
