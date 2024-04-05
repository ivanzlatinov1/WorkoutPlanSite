using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutPlanSite.Data.Data.Models.Enums;

namespace WorkoutPlanSite.Services.DTOs
{
    public class EquipmentDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 220)]
        public double? Weight { get; set; }

        [Required]
        public Plan Plan { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public TypeDTO Type { get; set; } = null!;

        [Url]
        public string? ImageUrl { get; set; }

    }
}
