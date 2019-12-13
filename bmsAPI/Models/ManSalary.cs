using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class ManSalary
    {
        public Manager Manager { get; set; }

        [Key]
        public int Id { get; set; }
        [Required]
        public int ManagerId { get; set; } //DB table relationship
        [Required]
        public double SalaryAmn { get; set; }
        public DateTime Date { get; set; } //current Date

        public List<Links> links = new List<Links>();
    }
}