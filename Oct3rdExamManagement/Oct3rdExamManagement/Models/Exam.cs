using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Oct3rdExamManagement.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [Range(0,100)]
        public int Mark { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Std { get; set; }
    }
}