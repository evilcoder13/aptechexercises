using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Oct28thEAP.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength=1)]
        public string Name { get; set; }
    }
}