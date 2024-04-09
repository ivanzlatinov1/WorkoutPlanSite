﻿using Microsoft.EntityFrameworkCore;
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
    public class EquipmentService : IEquipmentService
    {
        private readonly ApplicationDbContext context;
        public EquipmentService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(EquipmentDTO dto)
        {
            Equipment equipment = new()
            {
                Name = dto.Name,
                TypeId = dto.TypeId,
                Plan = dto.Plan,
                Metric = dto.Metric,
                Weight = dto.Weight,
                ImageUrl = dto.ImageUrl
            };

            await context.Equipments.AddAsync(equipment);
            await context.SaveChangesAsync();
            return equipment.Id;
        }

        public async Task DeleteAsync(int id)
        {
            Equipment equipment = await context.Equipments.FindAsync(id)
                ?? throw new KeyNotFoundException($"Equipment with id: {id} does not exist.");

            context.Equipments.Remove(equipment);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(EquipmentDTO dto)
        {
           Equipment equipment = await context.Equipments.FindAsync(dto.Id)
                ?? throw new KeyNotFoundException($"Equipment with id: {dto.Id} does not exist.");
            equipment.Name = dto.Name;
            equipment.Weight = dto.Weight;
            equipment.Plan = dto.Plan;
            equipment.Metric = dto.Metric;
            equipment.TypeId = dto.TypeId;
            equipment.ImageUrl = dto.ImageUrl;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EquipmentDTO>> GetAllAsync()
        {
            return await context.Equipments
                .Select(e => new EquipmentDTO()
                {
                    Id = e.Id,
                    Name = e.Name,
                    TypeId = e.TypeId,
                    Weight = e.Weight,
                    Plan = e.Plan,
                    Metric = e.Metric,
                    Type = new TypeDTO()
                    {
                        Id = e.Type.Id,
                        Name = e.Type.Name,
                    },
                    ImageUrl = e.ImageUrl
                })
                .ToArrayAsync();
        }

        public async Task<EquipmentDTO> GetByIdAsync(int id)
        {
            Equipment equipment = await context.Equipments.FindAsync(id)
                ?? throw new KeyNotFoundException($"Equipment with id: {id} does not exist.");
            EquipmentDTO dto = new EquipmentDTO()
            {
                Id = equipment.Id,
                Name = equipment.Name,
                TypeId = equipment.TypeId,
                Weight = equipment.Weight,
                Plan = equipment.Plan,
                Metric = equipment.Metric,
                Type = new TypeDTO()
                {
                    Id = equipment.Type.Id,
                    Name = equipment.Type.Name,
                },
                ImageUrl = equipment.ImageUrl
            };
            return dto;

        }

        public async Task<TypeDTO[]> GetTypesAsync()
        {
            return await context.Types.Select(t => new TypeDTO()
            {
                Id = t.Id,
                Name = t.Name,
            })
                .ToArrayAsync();
        }
    }
}
