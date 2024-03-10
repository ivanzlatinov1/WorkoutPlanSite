using System.ComponentModel.DataAnnotations;
using WorkoutPlanSite.Services.DTOs;

namespace WorkoutPlanSite.Models.Equipment
{
    public class EquipmentViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Weight { get; set; }

        public string Plan { get; set; } = null!;

        public string Type{ get; set; } = null!;

    }
}
