using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class EmpSalary
    {
        public Employee Employee { get; set; }

        [Key]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public double SalaryAmn { get; set; }
        public DateTime Date { get; set; }

        public List<Links> links = new List<Links>();
    }
}