using BuildingBlocks.Core.Domain;

namespace Training.Core.Domain
{
    public class Workout :Entity
    {
        public Workout()
        {
        }

        public string Name { get; set; }

        public float Duration { get; set; } 

        public int CaloriesBurned { get; set; }

        public int IntensityLevel { get; set; } 

        public int FatigueLevel { get; set; } 

        public string Notes { get; set; }

        public DateTime Time { get; set; }

        public WorkoutType Type { get; set; }

        public Workout(string name, float duration, int caloriesBurned, int intensityLevel, int fatigueLevel, string notes, DateTime time, WorkoutType type)
        {
            Name = name;
            Duration = duration;
            CaloriesBurned = caloriesBurned;
            IntensityLevel = intensityLevel;
            FatigueLevel = fatigueLevel;
            Notes = notes;
            Time = time;
            Type = type;
        }
    }
    public enum WorkoutType
    {
        Cardio,
        Strength,
        Flexibility,
        Balance,
        Mobility,
        Endurance,
        Other
    }

}
