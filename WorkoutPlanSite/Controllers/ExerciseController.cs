using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;
using WorkoutPlanSite.Data;
using WorkoutPlanSite.Data.Models;

namespace WorkoutPlanSite.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly ApplicationDbContext context;

        public ExerciseController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var exercises = await context.Exercises.ToArrayAsync();
            return View(exercises);
        }


        public async Task<IActionResult> Details(int id)
        {
            var exercise = context.Exercises.FindAsync(id);
            return View(exercise);
        }

        public ActionResult Create()
        {
            var exercise = new Exercise();
            return View(exercise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Exercise exercise)
        {
            try
            {
                await context.Exercises.AddAsync(exercise);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(exercise);
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
           Exercise? exercise = await context.Exercises.FindAsync(id);
            if(exercise == null)
            {
                return BadRequest($"Exercise with id {id} does not exist.");
            }
            return View(exercise);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Exercise exercise)
        {
            try
            {
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(exercise);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var exercise = await context.Exercises.FindAsync(id);
            return View(exercise);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Exercise exercise)
        {
            try
            {
                context.Exercises.Remove(exercise);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(exercise);
            }
        }
    }
}