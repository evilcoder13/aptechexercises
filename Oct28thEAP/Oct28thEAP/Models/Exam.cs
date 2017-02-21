using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Oct28thEAP.Models
{
    public class Exam
    {
        [Key, Column(Order=1)]
        public int StudentId { get; set; }
        [Key, Column(Order = 2)]
        public int ClassId { get; set; }
        [Required]
        [Range(0,100)]
        public int Mark { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Std { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class Cls { get; set; }
    }
}