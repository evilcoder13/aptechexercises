using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Oct5thMVCProjectManagement.Models
{
    public class Project
    {
        [Key]
        public int PrjId { get; set; }
        [Required]
        [StringLength(150, MinimumLength=2)]
        public string PrjName { get; set; }
        [Required]
        [DataType( System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime PrjStart { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime? PrjEnd { get; set; }

    }
}