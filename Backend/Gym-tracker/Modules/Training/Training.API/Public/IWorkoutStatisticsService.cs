using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.API.Dtos;

namespace Training.API.Public
{
    public interface IWorkoutStatisticsService
    {
        Result<List<WeeklyWorkoutStatsDto>> GetWeeklyStats(int year, int month, long userId);

    }
}
