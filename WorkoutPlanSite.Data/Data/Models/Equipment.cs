using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutPlanSite.Data.Data.Models.Enums;

namespace WorkoutPlanSite.Data.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(33)]
        public string Name { get; set; } = null!;

        [Range(0, 220)]
        public double? Weight { get; set; }

        [Required]
        public Plan Plan { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; } = null!;

        [Url]
        public string? ImageUrl { get; set; }


    }
}