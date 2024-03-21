using Microsoft.AspNetCore.Mvc;
using WorkoutPlanSite.Models.Exercise;
using WorkoutPlanSite.Services.DTOs;
using WorkoutPlanSite.Services.Interfaces;

namespace WorkoutPlanSite.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseService exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ExerciseDTO> exercises = await exerciseService.GetAllAsync();
            ExerciseViewModel[] exerciseViews = exercises.Select(x => new ExerciseViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Duration = x.Duration,
                EquipmentId = x.EquipmentId,
                EquipmentName = x.Equipment.Name,
            })
                .ToArray();
            return View(exercises);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ExerciseDTO exercise = await exerciseService.GetByIdAsync(id);
            ExerciseViewModel exerciseViewModel = new ExerciseViewModel()
            {
                Id = id,
                Name = exercise.Name,
                Description = exercise.Description,
                Duration = exercise.Duration,
                EquipmentId = exercise.EquipmentId,
                EquipmentName = exercise.Equipment.Name,
            };
            return View(exerciseViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var exercise = new ExerciseInputModel();
            return View(exercise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExerciseInputModel exercise)
        {
            try
            {
                ExerciseDTO dto = new ExerciseDTO()
                {
                    Id = exercise.Id,
                    Name = exercise.Name,
                    Description = exercise.Description,
                    Duration = exercise.Duration,
                    EquipmentId = exercise.EquipmentId,
                };
                await exerciseService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(exercise);
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            ExerciseDTO exercise = await exerciseService.GetByIdAsync(id);
            ExerciseInputModel exerciseInput = new ExerciseInputModel()
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                Duration = exercise.Duration,
                EquipmentId = exercise.EquipmentId,
            };
            return View(exerciseInput);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExerciseInputModel exercise)
        {
            try
            {
                ExerciseDTO dto = new ExerciseDTO()
                {
                    Id = exercise.Id,
                    Name = exercise.Name,
                    Description = exercise.Description,
                    Duration = exercise.Duration,
                    EquipmentId = exercise.EquipmentId,
                };
                await exerciseService.EditAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(exercise);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await exerciseService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}