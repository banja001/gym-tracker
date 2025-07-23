using BuildingBlocks.Core.UseCases;
using FluentResults;
using Training.API.Dtos;

namespace Training.API.Public
{
    public interface IWorkoutService
    {
        Result<PagedResult<WorkoutDto>> GetPaged(int page, int pageSize);
        Result<IEnumerable<WorkoutDto>> GetByUserId(long userId);
        Result<WorkoutDto> Create(WorkoutDto workoutDto);
        Result<WorkoutDto> Update(WorkoutDto workoutDto);
        Result Delete(int id);
        Result<WorkoutDto> Get(int id);

    }
}
