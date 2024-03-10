using System.ComponentModel.DataAnnotations;
using WorkoutPlanSite.Data.Models;

namespace WorkoutPlanSite.Services.DTOs
{
    public class TypeDTO
    {
        
            public int Id { get; set; }

            [Required]
            [StringLength(20, MinimumLength = 2)]
            public string Name { get; set; } = null!;

           public ICollection<EquipmentDTO> Equipments { get; set; } = new List<EquipmentDTO>();


    }
}