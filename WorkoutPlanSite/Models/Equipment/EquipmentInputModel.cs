using System.ComponentModel.DataAnnotations;
using WorkoutPlanSite.Data.Data.Models.Enums;
using WorkoutPlanSite.Services.DTOs;

namespace WorkoutPlanSite.Models.Equipment
{
    public class EquipmentInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name field is required.")]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Weight is required.")]
        [Range(1, 220)]
        [Display(Name = "Weight")]
        public double? Weight { get; set; }

        [Required]  
        [Display(Name = "Plan")]
        public Plan Plan { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [Display(Name = "Type")]
        public int TypeId { get; set; }

        public TypeDTO[]? Types { get; set; }

        [Url]
        [Display(Name = "Image link")]
        public string? ImageUrl { get; set; }

        public Plan[]? Plans { get; set; }
    }
}
