using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutPlanSite.Data.Data.Models.Enums;

namespace WorkoutPlanSite.Data.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [Range(1, 20)]
        public int Sets { get; set; }

        [Required]
        [Range(1, 100)]
        public int Repetitions { get; set; }

        [Required]
        public ExerciseDifficulty difficulty { get; set; }

        [Required]
        public int EquipmentId { get; set;}

        [Required]
        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; } = null!;

        [Url]
        public string? ImageURL { get; set; }


    }
}
