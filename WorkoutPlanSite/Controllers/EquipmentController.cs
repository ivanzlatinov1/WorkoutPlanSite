using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlanSite.Data.Data.Models.Enums;
using WorkoutPlanSite.Models.Equipment;
using WorkoutPlanSite.Services.DTOs;
using WorkoutPlanSite.Services.Interfaces;

namespace WorkoutPlanSite.Controllers
{
    [Authorize]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? plan = null)
        {
            IEnumerable<EquipmentDTO> equipments = await equipmentService.GetAllAsync();
            IEnumerable<EquipmentViewModel> views = equipments.Select(e => new EquipmentViewModel
            {
                Plan = e.Plan.ToString(),
                Id = e.Id,
                Name = e.Name,
                Weight = e.Weight,
                Type = e.Type.Name,
                ImageUrl = e.ImageUrl
            });

            if(plan != null)
            {
                views = views.Where(e => e.Plan == plan);
            }

            return View(views);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            EquipmentDTO dto = await equipmentService.GetByIdAsync(id);
            EquipmentViewModel equipment = new()
            {
                Plan = dto.Plan.ToString(),
                Id = dto.Id,
                Name = dto.Name,
                Weight = dto.Weight,
                Type = dto.Type.Name,
                ImageUrl = dto.ImageUrl
            };
            return View(equipment);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            Array plans = typeof(Plan).GetEnumValues();

            return View(new EquipmentInputModel() {
                Types = await equipmentService.GetTypesAsync(),
                Plans = (Plan[])plans
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(EquipmentInputModel input)
        {
            if (!ModelState.IsValid)
            {
                Array plans = typeof(Plan).GetEnumValues();
                input.Plans = (Plan[])plans;

                input.Types = await equipmentService.GetTypesAsync();
                return View(input);
            }
            EquipmentDTO dto = new()
            {
                Id = input.Id,
                Name = input.Name,
                Weight = input.Weight,
                Plan = input.Plan,
                TypeId = input.TypeId,
                ImageUrl = input.ImageUrl
            };
            await equipmentService.CreateAsync(dto);
            return RedirectToAction(nameof(Index), new {plan = input.Plan});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Array plans = typeof(Plan).GetEnumValues();

            EquipmentDTO dto = await equipmentService.GetByIdAsync(id);
            EquipmentInputModel equipment = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Weight = dto.Weight,
                Plan = dto.Plan,
                TypeId = dto.TypeId,
                Types = await equipmentService.GetTypesAsync(),
                ImageUrl = dto.ImageUrl,
                Plans = (Plan[])plans
            };
            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EquipmentInputModel input)
        {
            if (!ModelState.IsValid)
            {
                Array plans = typeof(Plan).GetEnumValues();
                ViewBag.Plans = (Plan[])plans;

                input.Types = await equipmentService.GetTypesAsync();
                return View(input);
            }
            EquipmentDTO dto = new()
            {
                Id = input.Id,
                Name = input.Name,
                Weight = input.Weight,
                Plan = input.Plan,
                TypeId = input.TypeId,
                ImageUrl = input.ImageUrl
            };
            await equipmentService.EditAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await equipmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
