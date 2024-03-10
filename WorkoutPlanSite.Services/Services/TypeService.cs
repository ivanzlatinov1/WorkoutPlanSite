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
using Type = WorkoutPlanSite.Data.Models.Type;

namespace WorkoutPlanSite.Services.Services
{
    public class TypeService : ITypeService
    {
        private readonly ApplicationDbContext context;
        public TypeService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(TypeDTO dto)
        {
            Type type = new()
            {
                Name = dto.Name,
            };
            await context.Types.AddAsync(type);
            await context.SaveChangesAsync();
            return type.Id;
        }

        public async Task DeleteAsync(int id)
        {
            Type type = await context.Types.FindAsync(id)
                ?? throw new KeyNotFoundException($"Type with id: {id} does not exist.");

            context.Types.Remove(type);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(TypeDTO dto)
        {
            Type type = await context.Types.FindAsync(dto.Id)
                 ?? throw new KeyNotFoundException($"Type with id: {dto.Id} does not exist.");
            type.Name = dto.Name;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TypeDTO>> GetAllAsync()
        {
            return await context.Types
               .Select(t => new TypeDTO()
               {
                   Id = t.Id,
                   Name = t.Name,
                   Equipments = t.Equipments
                   .Select(e => new EquipmentDTO()
                   {
                       Id = e.Id,
                       Name = e.Name,
                       Weight = e.Weight,
                       TypeId = e.TypeId,
                   })

                   .ToArray()
               })
               .ToArrayAsync();
        }

        public async Task<TypeDTO> GetByIdAsync(int id)
        {
            Type type = await context.Types.FindAsync(id)
               ?? throw new KeyNotFoundException($"Type with id: {id} does not exist.");
            TypeDTO dto = new TypeDTO()
            {
                Id = type.Id,
                Name = type.Name,
                Equipments = type.Equipments
                   .Select(e => new EquipmentDTO()
                   {
                       Id = e.Id,
                       Name = e.Name,
                       Weight = e.Weight,
                       TypeId = e.TypeId,
                   })
                   .ToArray()
            };
            return dto;
        }
    }
}
