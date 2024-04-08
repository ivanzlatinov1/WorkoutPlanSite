﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WorkoutPlanSite.Data.Data.Models.Enums;
using WorkoutPlanSite.Data.Models;
using WorkoutPlanSite.Models.Equipment;
using WorkoutPlanSite.Models.Exercise;
using WorkoutPlanSite.Services.DTOs;
using WorkoutPlanSite.Services.Interfaces;
using WorkoutPlanSite.Services.Services;

namespace WorkoutPlanSite.Controllers
{
    [Authorize]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }
        public async Task<IActionResult> Index(string? diff = null)
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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.HideFooter = true;

            ExerciseDTO exercise = await exerciseService.GetByIdAsync(id);
            ExerciseViewModel exerciseViewModel = new ExerciseViewModel()
            {
                Id = id,
                Name = exercise.Name,
                Description = exercise.Description,
                Sets = exercise.Sets,
                Repetitions= exercise.Repetitions,
                Difficulty = exercise.difficulty.ToString(),
                EquipmentId = exercise.EquipmentId,
                EquipmentName = exercise.Equipment.Name,
                ImageURL = exercise.ImageURL,
            };

            return View(exerciseViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Array difficulties = typeof(ExerciseDifficulty).GetEnumValues();
            ViewBag.Difficulties = (ExerciseDifficulty[])difficulties;

            EquipmentDTO[] equipments = await exerciseService.GetEquipmentsAsync();
            EquipmentViewModel[] views = equipments.Select(dto => new EquipmentViewModel
            {
                Plan = dto.Plan.ToString(),
                Id = dto.Id,
                Name = dto.Name,
                Weight = dto.Weight,
                Type = dto.Type.Name,
                ImageUrl = dto.ImageUrl
            }).ToArray();

            ExerciseInputModel exercise = new() { Equipments = views};
            return View(exercise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExerciseInputModel exercise)
        {
            if(!ModelState.IsValid)
            {
                Array difficulties = typeof(ExerciseDifficulty).GetEnumValues();
                ViewBag.Difficulties = (ExerciseDifficulty[])difficulties;

                EquipmentDTO[] equipments = await exerciseService.GetEquipmentsAsync();
                EquipmentViewModel[] views = equipments.Select(dto => new EquipmentViewModel
                {
                    Plan = dto.Plan.ToString(),
                    Id = dto.Id,
                    Name = dto.Name,
                    Weight = dto.Weight,
                    Type = dto.Type.Name,
                    ImageUrl = dto.ImageUrl
                }).ToArray();

                return View(new ExerciseInputModel() { Equipments = views });
            }
            try
            {
                ExerciseDTO dto = new ExerciseDTO()
                {
                    Id = exercise.Id,
                    Name = exercise.Name,
                    Description = exercise.Description,
                    Sets = exercise.Sets,
                    Repetitions = exercise.Repetitions,
                    difficulty = exercise.Difficulty,
                    EquipmentId = exercise.EquipmentId,
                    ImageURL = exercise.ImageURL,
                };
                await exerciseService.CreateAsync(dto);
                return RedirectToAction(nameof(Index), new { diff = exercise.Difficulty });
            }
            catch
            {
                return View(exercise);
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            Array difficulties = typeof(ExerciseDifficulty).GetEnumValues();
            ViewBag.Difficulties = (ExerciseDifficulty[])difficulties;

            ExerciseDTO exercise = await exerciseService.GetByIdAsync(id);
            ExerciseInputModel exerciseInput = new ExerciseInputModel()
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                Sets = exercise.Sets,
                Repetitions= exercise.Repetitions,
                Difficulty = exercise.difficulty,
                EquipmentId = exercise.EquipmentId,
                ImageURL = exercise.ImageURL,
                Equipments = (await exerciseService.GetEquipmentsAsync())
                .Select(x => new EquipmentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Weight = x.Weight,
                    ImageUrl = x.ImageUrl,
                    Plan = x.Plan.ToString(),
                    Type = x.Type.Name,
                })
                .ToArray()
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
                    Sets = exercise.Sets,
                    Repetitions= exercise.Repetitions,
                    difficulty = exercise.Difficulty,
                    EquipmentId = exercise.EquipmentId,
                    ImageURL = exercise.ImageURL,
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