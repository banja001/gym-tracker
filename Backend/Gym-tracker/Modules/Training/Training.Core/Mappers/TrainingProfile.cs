using AutoMapper;
using Training.API.Dtos;
using Training.Core.Domain;


namespace Training.Core.Mappers
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile() 
        {
            CreateMap<WorkoutDto, Workout>().ReverseMap();
        }
    }
}
