﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutPlanSite.Data.Models;
using WorkoutPlanSite.Data.Data.Models.Enums;

namespace WorkoutPlanSite.Services.DTOs
{
    public class ExerciseDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [StringLength(100, MinimumLength = 2)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(1, 20)]
        public int Sets { get; set; }

        [Required]
        [Range(1, 100)]
        public int Repetitions { get; set; }

        [Required]
        public ExerciseDifficulty difficulty { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        [Required]
        public EquipmentDTO Equipment { get; set; } = null!;

        [Url]
        public string? ImageURL { get; set; }
    }
}
