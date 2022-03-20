using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.DAL;
using TaskList.Domain.Model;

namespace TaskList.WebApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private TaskListDBContext _db;
        public TaskController(ILogger<TaskController> logger, TaskListDBContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.TaskItem.AsEnumerable());
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View(new TaskItem());
        }

        [HttpPost]
        public IActionResult Create(TaskItem item)
        {
            if(ModelState.IsValid)
            {
                _db.Add(item);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(item);

        }


        public IActionResult Edit(int Id)
        {

            return View(_db.TaskItem.FirstOrDefault(x => x.Id==Id));
        }

        [HttpPost]
        public IActionResult Edit(TaskItem item)
        {
            if (ModelState.IsValid)
            {
                var model = _db.TaskItem.Find(item.Id);
                model.TaskName = item.TaskName;
                model.IsCompleted = item.IsCompleted;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);

        }
        public IActionResult Delete(int Id)
        {
            if(ModelState.IsValid)
            {
                var model = _db.TaskItem.Find(Id);
                _db.TaskItem.Remove(model);
                _db.SaveChanges();

                
            }
            return RedirectToAction("Index");
        }

    }
}
