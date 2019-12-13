using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class MangrTransection
    {
        public Branch Branch { get; set; }
 
        [Key]
        public int Id { get; set; }
        [Required]
        public int ManagerId { get; set; }
      
        [Required]
        public int BranchId { get; set; }

        [Required]
        public double Amount { get; set; }
        [Required]
        public string TransDate { get; set; } //current Date 

        public bool Authorized { get; set; } = false;

        public List<Links> links = new List<Links>();

    }
}