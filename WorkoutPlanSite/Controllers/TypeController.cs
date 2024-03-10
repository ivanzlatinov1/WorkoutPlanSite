using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlanSite.Data;

namespace WorkoutPlanSite.Controllers
{
    public class TypeController : Controller
    {
        private readonly ApplicationDbContext context;

        public TypeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: TypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
