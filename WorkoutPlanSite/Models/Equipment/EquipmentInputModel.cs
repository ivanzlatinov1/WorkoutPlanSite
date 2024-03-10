using System.ComponentModel.DataAnnotations;
using WorkoutPlanSite.Data.Data.Models.Enums;
using WorkoutPlanSite.Services.DTOs;

namespace WorkoutPlanSite.Models.Equipment
{
    public class EquipmentInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 50)]
        [Display(Name = "Weight")]
        public double Weight { get; set; }

        [Required]
        [Display(Name = "Plan")]

        public Plan Plan { get; set; }

        [Required]
        [Display(Name = "Type")]
        public int TypeId { get; set; }

        public TypeDTO[] Types { get; set; } = null!;
    }
}
