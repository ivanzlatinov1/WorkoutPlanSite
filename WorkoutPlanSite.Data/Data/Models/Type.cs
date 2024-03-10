using System.ComponentModel.DataAnnotations;

namespace WorkoutPlanSite.Data.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(33)]
        public string Name { get; set; } = null!;

        public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
