using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.DAL;

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
    }
}
