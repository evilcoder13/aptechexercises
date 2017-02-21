using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Nov2ndEAP
{
    public class TaskGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength=1)]
        public string Name { get; set; }
    }
}
