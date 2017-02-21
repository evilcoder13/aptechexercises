using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Oct5thMVCProjectManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        [StringLength(150, MinimumLength=2)]
        public string EmpName { get; set; }
        [StringLength(15, MinimumLength = 1)]
        public string EmpDepartment { get; set; }
    }
}