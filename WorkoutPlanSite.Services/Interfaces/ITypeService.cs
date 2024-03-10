using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutPlanSite.Services.DTOs;

namespace WorkoutPlanSite.Services.Interfaces
{
    public interface ITypeService
    {
        Task<int> CreateAsync(TypeDTO dto);
        Task EditAsync(TypeDTO dto);
        Task DeleteAsync(int id);
        Task<TypeDTO> GetByIdAsync(int id);
        Task<IEnumerable<TypeDTO>> GetAllAsync();
    }
}
