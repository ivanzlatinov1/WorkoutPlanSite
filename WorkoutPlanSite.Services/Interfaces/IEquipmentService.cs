using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutPlanSite.Services.DTOs;

namespace WorkoutPlanSite.Services.Interfaces
{
    public interface IEquipmentService
    {
        Task<int> CreateAsync(EquipmentDTO dto);
        Task EditAsync(EquipmentDTO dto);
        Task DeleteAsync(int id);
        Task<EquipmentDTO> GetByIdAsync(int id);
        Task<IEnumerable<EquipmentDTO>> GetAllAsync();
    }
}
