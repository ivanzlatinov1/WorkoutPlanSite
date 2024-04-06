using System.ComponentModel.DataAnnotations;
using WorkoutPlanSite.Data.Data.Models.Enums;
using WorkoutPlanSite.Services.DTOs;

namespace WorkoutPlanSite.Models.Exercise
{
    public class ExerciseInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(1, 120)]
        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Difficulty")]
        public ExerciseDifficulty Difficulty { get; set; }

        [Required]
        [Display(Name = "Equipment")]
        public int EquipmentId { get; set; }

        public EquipmentDTO[]? Equipment { get; set; }

        [Url]
        [Display(Name = "Image link")]
        public string? ImageURL { get; set; }

    }
}
