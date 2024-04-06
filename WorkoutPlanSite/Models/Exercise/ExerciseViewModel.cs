using WorkoutPlanSite.Data.Data.Models.Enums;

namespace WorkoutPlanSite.Models.Exercise
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Sets { get; set; }

        public int Repetitions { get; set; }

        public string Difficulty { get; set; } = null!;

        public int EquipmentId { get; set; }

        public string EquipmentName { get; set; } = null!;

        public string? ImageURL { get; set; }
    }
}
