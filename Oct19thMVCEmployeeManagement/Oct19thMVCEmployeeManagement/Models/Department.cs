using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Oct19thMVCEmployeeManagement.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength=2)]
        public string Name { get; set; }
        public virtual ICollection<Employee> Emp { get; set; }
    }
}