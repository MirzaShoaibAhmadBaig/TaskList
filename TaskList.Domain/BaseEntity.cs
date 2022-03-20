using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Domain
{
   public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        [StringLength(255)]
        public string UpdatedBy { get; set; }
        [ScaffoldColumn(false)]
        public DateTime Updateddate { get; set; }
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }

    }
}
