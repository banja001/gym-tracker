using System.ComponentModel.DataAnnotations;

namespace Training.API.Dtos
{
    public class WorkoutDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [Range(0.1, float.MaxValue, ErrorMessage = "Duration must be greater than 0.")]
        public float Duration { get; set; }

        [Required(ErrorMessage = "CaloriesBurned is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "CaloriesBurned must be non-negative.")]
        public int CaloriesBurned { get; set; }

        [Required(ErrorMessage = "IntensityLevel is required.")]
        [Range(1, 10, ErrorMessage = "IntensityLevel must be between 1 and 10.")]
        public int IntensityLevel { get; set; }

        [Required(ErrorMessage = "FatigueLevel is required.")]
        [Range(1, 10, ErrorMessage = "FatigueLevel must be between 1 and 10.")]
        public int FatigueLevel { get; set; }

        public string Notes { get; set; }

        [Required(ErrorMessage = "Time is required.")]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "Workout Type is required.")]
        [EnumDataType(typeof(WorkoutType), ErrorMessage = "Invalid workout type.")]
        public WorkoutType Type { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public long UserId { get; set; }
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
