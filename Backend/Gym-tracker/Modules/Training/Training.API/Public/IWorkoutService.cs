using BuildingBlocks.Core.UseCases;
using FluentResults;
using Training.API.Dtos;

namespace Training.API.Public
{
    public interface IWorkoutService
    {
        Result<PagedResult<WorkoutDto>> GetPaged(int page, int pageSize);
    }
}
