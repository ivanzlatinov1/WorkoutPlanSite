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
        public async Task<IActionResult> Index(string plan)
        {
            IEnumerable<EquipmentViewModel> equipments = (await equipmentService.GetAllAsync())
                .Where(e => e.Plan == Enum.Parse<Plan>(plan))
                .Select(e => new EquipmentViewModel
                {
                    Plan = e.Plan.ToString(),
                    Id = e.Id,
                    Name = e.Name,
                    Weight = e.Weight,
                    Type = e.Type.Name
                });
            return View(equipments);
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
                Type = dto.Type.Name
            };
            return View(equipment);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View(new EquipmentInputModel() { Types = await equipmentService.GetTypesAsync() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(EquipmentInputModel input)
        {
            if (!ModelState.IsValid)
            {
                input.Types = await equipmentService.GetTypesAsync();
                return View(input);
            }
            EquipmentDTO dto = new()
            {
                Id = input.Id,
                Name = input.Name,
                Weight = input.Weight,
                Plan = input.Plan,
                TypeId = input.TypeId
            };
            await equipmentService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            EquipmentDTO dto = await equipmentService.GetByIdAsync(id);
            EquipmentInputModel equipment = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Weight = dto.Weight,
                Plan = dto.Plan,
                TypeId = dto.TypeId,
                Types = await equipmentService.GetTypesAsync()
            };
            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(EquipmentInputModel input)
        {
            if (!ModelState.IsValid)
            {
                input.Types = await equipmentService.GetTypesAsync();
                return View(input);
            }
            EquipmentDTO dto = new()
            {
                Id = input.Id,
                Name = input.Name,
                Weight = input.Weight,
                Plan = input.Plan,
                TypeId = input.TypeId
            };
            await equipmentService.EditAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            await equipmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
