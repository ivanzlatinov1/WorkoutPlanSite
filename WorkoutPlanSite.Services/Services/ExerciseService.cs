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
                Sets = dto.Sets,
                Repetitions = dto.Repetitions,
                difficulty = dto.difficulty,
                EquipmentId = dto.EquipmentId,
                ImageURL = dto.ImageURL
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
            exercise.Sets = dto.Sets;
            exercise.Repetitions = dto.Repetitions;
            exercise.difficulty = dto.difficulty;
            exercise.EquipmentId = dto.EquipmentId;
            exercise.ImageURL = dto.ImageURL;
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
                    Sets = e.Sets,
                    Repetitions = e.Repetitions,
                    difficulty = e.difficulty,
                    EquipmentId = e.EquipmentId,
                    Equipment = new EquipmentDTO()
                    {
                        Id = e.Equipment.Id,
                        Name = e.Equipment.Name,
                        TypeId = e.Equipment.TypeId,
                        Weight = e.Equipment.Weight,
                    },
                    ImageURL = e.ImageURL
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
                Sets = exercise.Sets,
                Repetitions = exercise.Repetitions,
                difficulty= exercise.difficulty,
                EquipmentId = exercise.EquipmentId,
                Equipment = new EquipmentDTO()
                {
                    Id = exercise.Equipment.Id,
                    Name = exercise.Equipment.Name,
                    TypeId = exercise.Equipment.TypeId,
                    Weight = exercise.Equipment.Weight,
                },
                ImageURL = exercise.ImageURL
            };
            return dto;
        }

        public async Task<EquipmentDTO[]> GetEquipmentsAsync()
        {
            var equipments = await context.Equipments.Select(t => new EquipmentDTO()
            {
                Id = t.Id,
                Name = t.Name,
                Type = new TypeDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                }
            })
                .ToArrayAsync();
            return equipments;
        }

    }
}
