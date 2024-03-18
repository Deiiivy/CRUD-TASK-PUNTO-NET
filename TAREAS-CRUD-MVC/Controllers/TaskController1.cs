using Microsoft.AspNetCore.Mvc;
using TAREAS_CRUD_MVC.Models;
using System.Linq;

namespace TAREAS_CRUD_MVC.Controllers
{
    public class TaskController1 : Controller
    {
        private readonly TaskContext _context;

        public TaskController1(TaskContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TAREAS_CRUD_MVC.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }


        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View("Editar", task);
        }

        [HttpPost]
        public IActionResult Edit(TAREAS_CRUD_MVC.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Update(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
