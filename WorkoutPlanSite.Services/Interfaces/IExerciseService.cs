using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutPlanSite.Services.DTOs;

namespace WorkoutPlanSite.Services.Interfaces
{
    public interface IExerciseService
    {
        Task<int> CreateAsync(ExerciseDTO dto);
        Task EditAsync(ExerciseDTO dto);
        Task DeleteAsync(int id);
        Task<ExerciseDTO> GetByIdAsync(int id);
        Task<IEnumerable<ExerciseDTO>> GetAllAsync();
    }
}
