using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Domain.Model
{
    public class TaskItem : BaseEntity
    {
        [StringLength(255)]
        [DisplayName("Task Name")]
        public string TaskName { get; set; }
        [DisplayName("Is Completed")]
        public bool IsCompleted { get; set; }
    }
}
