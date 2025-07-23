using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.API.Dtos
{
    public class WeeklyWorkoutStatsDto
    {
        public int WeekNumber { get; set; }
        public float TotalDuration { get; set; }
        public int WorkoutCount { get; set; }
        public double AverageIntensity { get; set; }
        public double AverageFatigue { get; set; }
    }
}
