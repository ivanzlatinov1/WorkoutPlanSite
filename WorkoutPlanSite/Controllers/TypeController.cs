using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlanSite.Models.Type;
using WorkoutPlanSite.Services.DTOs;
using WorkoutPlanSite.Services.Interfaces;

namespace WorkoutPlanSite.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService typeService;

        public TypeController(ITypeService typeService)
        {
            this.typeService = typeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<TypeDTO> types = await typeService.GetAllAsync();
            TypeViewModel[] typeViews = types.Select(x => new TypeViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            })
                .ToArray();
            return View(typeViews);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            TypeDTO type = await typeService.GetByIdAsync(id);
            TypeViewModel typeViewModel = new TypeViewModel()
            {
               Id= id,
               Name = type.Name,
            };
            return View(typeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var types = new TypeInputModel();
            return View(types);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypeInputModel type)
        {
            try
            {
                TypeDTO dto = new TypeDTO()
                {
                    Id = type.Id,
                    Name = type.Name,
                };
                await typeService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(type);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            TypeDTO type = await typeService.GetByIdAsync(id);
            TypeInputModel typeInput = new()
            {
                Id = type.Id,
                Name = type.Name,
                Equipments = type.Equipments,
            };
            return View(typeInput);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TypeInputModel type)
        {
            try
            {
                TypeDTO dto = new TypeDTO()
                {
                    Id = type.Id,
                    Name = type.Name,
                    Equipments = type.Equipments
                };
                await typeService.EditAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(type);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await typeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
