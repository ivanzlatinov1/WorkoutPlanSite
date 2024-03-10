using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutPlanSite.Data.Data.Models.Enums;
using Type = WorkoutPlanSite.Data.Models.Type;

namespace WorkoutPlanSite.Data.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(33)]
        public string Name { get; set; } = null!;


        [Required]
        [Range(1, 50)]
        public double Weight { get; set; }

        [Required]
        public Plan Plan { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; } = null!;


    }
}