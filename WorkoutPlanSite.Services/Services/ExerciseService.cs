using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutPlanSite.Data;
using WorkoutPlanSite.Data.Models;
using WorkoutPlanSite.Services.DTOs;
using WorkoutPlanSite.Services.Interfaces;

namespace WorkoutPlanSite.Services.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext context;
        public ExerciseService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(ExerciseDTO dto)
        {
            Exercise exercise = new()
            {
                Name = dto.Name,
                Description = dto.Description,
                Duration = dto.Duration,
                EquipmentId = dto.EquipmentId,
            };

            await context.Exercises.AddAsync(exercise);
            await context.SaveChangesAsync();
            return exercise.Id;
        }

        public async Task DeleteAsync(int id)
        {
            Exercise exercise = await context.Exercises.FindAsync(id)
                ?? throw new KeyNotFoundException($"Exercise with id: {id} does not exist.");

            context.Exercises.Remove(exercise);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(ExerciseDTO dto)
        {
            Exercise exercise = await context.Exercises.FindAsync(dto.Id)
                 ?? throw new KeyNotFoundException($"Exercise with id: {dto.Id} does not exist.");
            exercise.Name = dto.Name;
            exercise.Description = dto.Description;
            exercise.Duration = dto.Duration;
            exercise.EquipmentId = dto.EquipmentId;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllAsync()
        {
            return await context.Exercises
                .Select(e => new ExerciseDTO()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Duration = e.Duration,
                    EquipmentId = e.EquipmentId,
                    Equipment = new EquipmentDTO()
                    {
                        Id = e.Equipment.Id,
                        Name = e.Equipment.Name,
                        TypeId = e.Equipment.TypeId,
                        Weight = e.Equipment.Weight,
                    }
                })
                .ToArrayAsync();
        }

        public async Task<ExerciseDTO> GetByIdAsync(int id)
        {
            Exercise exercise = await context.Exercises.FindAsync(id)
                ?? throw new KeyNotFoundException($"Exercise with id: {id} does not exist.");
            ExerciseDTO dto = new ExerciseDTO()
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                Duration = exercise.Duration,
                EquipmentId = exercise.EquipmentId,
                Equipment = new EquipmentDTO()
                {
                    Id = exercise.Equipment.Id,
                    Name = exercise.Equipment.Name,
                    TypeId = exercise.Equipment.TypeId,
                    Weight = exercise.Equipment.Weight,
                }
            };
            return dto;
        }
    }
}
