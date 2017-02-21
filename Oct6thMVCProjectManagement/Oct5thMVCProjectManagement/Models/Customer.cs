using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Oct5thMVCProjectManagement.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }
        [Required]
        [StringLength(150, MinimumLength=2)]
        public string CustName { get; set; }
        [Required]
        [EmailAddress]
        public string CustEmail { get; set; }
        [Required]
        [Phone]
        public string CustPhone { get; set; }
    }
}