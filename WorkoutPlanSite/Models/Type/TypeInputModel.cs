using System.ComponentModel.DataAnnotations;
using WorkoutPlanSite.Services.DTOs;

namespace WorkoutPlanSite.Models.Type
{
    public class TypeInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        public ICollection<EquipmentDTO> Equipments { get; set; } = new List<EquipmentDTO>();
    }
}
