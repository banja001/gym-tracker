using AutoMapper;
using BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.API.Dtos;
using Training.API.Public;
using Training.Core.Domain;
using Training.Core.Domain.RepositoryInterfaces;

namespace Training.Core.UseCases
{
    public class WorkoutStatisticsService :BaseService<WeeklyWorkoutStatsDto,Workout>, IWorkoutStatisticsService
    {
        protected readonly IMapper _mapper;
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutStatisticsService(IWorkoutRepository crudRepository, IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
            _workoutRepository = crudRepository;
        }

        public Result<List<WeeklyWorkoutStatsDto>> GetWeeklyStats(int year, int month, long userId)
        {
            var workoutsInMonth = _workoutRepository.GetWorkoutsInMonth(year, month, userId);
            var weeklyStats = workoutsInMonth
                .GroupBy(w => GetWeekOfMonth(w.Time))
                .Select(g => new WeeklyWorkoutStatsDto
                {
                    WeekNumber = g.Key,
                    TotalDuration = g.Sum(w => w.Duration),
                    WorkoutCount = g.Count(),
                    AverageIntensity = g.Average(w => w.IntensityLevel),
                    AverageFatigue = g.Average(w => w.FatigueLevel)
                })
                .OrderBy(x => x.WeekNumber)
                .ToList();

            return weeklyStats;
        }
        private int GetWeekOfMonth(DateTime date)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            if (firstDayOfWeek == 0) firstDayOfWeek = 7;

            var day = date.Day + firstDayOfWeek - 1;
            return (day / 7) + 1;
        }
    }
}
