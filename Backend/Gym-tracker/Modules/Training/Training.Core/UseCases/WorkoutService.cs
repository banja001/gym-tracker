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
    }
}
