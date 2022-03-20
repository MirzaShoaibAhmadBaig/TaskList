using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Domain.Model;

namespace TaskList.DAL
{
    public partial class TaskListDBContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TaskListDBContext(DbContextOptions<TaskListDBContext> con, IHttpContextAccessor httpContextAccessor) :base(con) 
        {
            _httpContextAccessor = httpContextAccessor;

        }

       public DbSet<TaskItem> TaskItems { get; set; }

    }
}
