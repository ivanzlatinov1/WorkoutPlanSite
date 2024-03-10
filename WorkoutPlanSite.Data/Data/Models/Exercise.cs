using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int Duration { get; set; }

        [Required]
        public int EquipmentId { get; set;}

        [Required]
        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; } = null!;
    }
}
