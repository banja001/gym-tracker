namespace Training.API.Dtos
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float Duration { get; set; }

        public int CaloriesBurned { get; set; }

        public int IntensityLevel { get; set; }

        public int FatigueLevel { get; set; }

        public string Notes { get; set; }

        public DateTime Time { get; set; }

        public WorkoutType Type { get; set; }
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
