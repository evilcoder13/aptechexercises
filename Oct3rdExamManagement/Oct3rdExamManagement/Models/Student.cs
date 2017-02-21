using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Oct3rdExamManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(150, MinimumLength=2)]
        public string Name { get; set; }
        [Required]
        [DataType( System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public virtual ICollection<Exam> Ex { get; set; }
    }
}