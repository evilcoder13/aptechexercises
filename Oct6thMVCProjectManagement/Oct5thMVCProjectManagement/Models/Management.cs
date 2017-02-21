using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Oct5thMVCProjectManagement.Models
{
    public class Management
    {
        [Key, Column(Order=1)]
        public int EmpId { get; set; }
        [Key, Column(Order = 2)]
        public int CustId { get; set; }
        [Key, Column(Order = 3)]
        public int PrjId { get; set; }
        public string Note { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Emp { get; set; }
        [ForeignKey("CustId")]
        public virtual Customer Cust { get; set; }
        [ForeignKey("PrjId")]
        public virtual Project Prj { get; set; }
    }
}