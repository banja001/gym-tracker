using AutoMapper;
using BuildingBlocks.Core.UseCases;
using FluentResults;
using Training.API.Dtos;
using Training.API.Public;
using Training.Core.Domain;
using Training.Core.Domain.RepositoryInterfaces;

namespace Training.Core.UseCases
{
    public class WorkoutService : CrudService<WorkoutDto, Workout>, IWorkoutService
    {
        protected readonly IMapper _mapper;
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
            _mapper = mapper;
            _workoutRepository = crudRepository;
        }

        public Result<IEnumerable<WorkoutDto>> GetByUserId(long userId)
        {
            var workouts = _workoutRepository.GetByUserId(userId);

            if (workouts == null || !workouts.Any())
                return Result.Fail<IEnumerable<WorkoutDto>>(FailureCode.NotFound);

            var result = workouts.Select(MapToDto).ToList();

            return Result.Ok<IEnumerable<WorkoutDto>>(result);
        }

        public override Result<WorkoutDto> Create(WorkoutDto workoutDto)
        {
            return base.Create(workoutDto);
        }
        public override Result<WorkoutDto> Update(WorkoutDto workoutDto)
        {
            var existingWorkout = _workoutRepository.Get(workoutDto.Id);
            if (existingWorkout == null)
                return Result.Fail<WorkoutDto>(FailureCode.NotFound);

            return base.Update(workoutDto);
        }

        public override Result Delete(int id)
        {
            var existingWorkout = _workoutRepository.Get(id);
            if (existingWorkout == null)
                return Result.Fail(FailureCode.NotFound);

            return base.Delete(id);
        }
    }
}
