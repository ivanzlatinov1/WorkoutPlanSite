namespace WorkoutPlanSite.Models.Exercise
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Duration { get; set; }

        public int EquipmentId { get; set; }

        public string EquipmentName { get; set; } = null!;
    }
}
