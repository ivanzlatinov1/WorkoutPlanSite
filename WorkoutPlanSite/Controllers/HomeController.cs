using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;
using WorkoutPlanSite.Data;
using WorkoutPlanSite.Data.Data.Models.Enums;
using WorkoutPlanSite.Models;
using WorkoutPlanSite.Models.Equipment;
using WorkoutPlanSite.Models.Exercise;
using WorkoutPlanSite.Services.DTOs;
using WorkoutPlanSite.Services.Interfaces;
using WorkoutPlanSite.Services.Services;

namespace WorkoutPlanSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEquipmentService equipmentService;
        private readonly IExerciseService exerciseService;
        public HomeController(ILogger<HomeController> logger,
            IExerciseService exerciseService, IEquipmentService equipmentService)
        {
            _logger = logger;
            this.equipmentService = equipmentService;
            this.exerciseService = exerciseService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Explore()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Equipments(string? plan)
        {
            IEnumerable<EquipmentDTO> equipments = await equipmentService.GetAllAsync();
            IEnumerable<EquipmentViewModel> views = equipments.Select(e => new EquipmentViewModel
            {
                Plan = e.Plan.ToString(),
                Metric = e.Metric.ToString(),
                Id = e.Id,
                Name = e.Name,
                Weight = e.Weight,
                Type = e.Type.Name,
                ImageUrl = e.ImageUrl
            });

            if (plan != null)
            {
                views = views.Where(e => e.Plan == plan);
            }

            return View(views);
        }

        [HttpGet]
        public async Task<IActionResult> Exercises(string? diff = null)
        {
            IEnumerable<ExerciseDTO> exercises = await exerciseService.GetAllAsync();
            IEnumerable<ExerciseViewModel> exerciseViews = exercises.Select(x => new ExerciseViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Sets = x.Sets,
                Repetitions = x.Repetitions,
                Difficulty = x.difficulty.ToString(),
                EquipmentId = x.EquipmentId,
                EquipmentName = x.Equipment.Name,
                ImageURL = x.ImageURL,
            })
            .ToArray();

            if (diff != null)
            {
                exerciseViews = exerciseViews.Where(e => e.Difficulty == diff);
            }

            return View(exerciseViews);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
