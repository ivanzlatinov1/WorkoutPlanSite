using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WorkoutPlanSite.Data.Data.Models.Enums;
using WorkoutPlanSite.Models.Equipment;
using WorkoutPlanSite.Services.DTOs;
using WorkoutPlanSite.Services.Interfaces;
using WorkoutPlanSite.Services.Services;

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
        // GET: EquipmentController
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

        // GET: EquipmentController/Details/5
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

        // GET: EquipmentController/Create
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create()
        {
            return View(new EquipmentInputModel() { Types = await equipmentService.GetTypesAsync() });
        }

        // POST: EquipmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
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

        // GET: EquipmentController/Edit/5
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

        // POST: EquipmentController/Edit/5
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



        // POST: EquipmentController/Delete/5
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
