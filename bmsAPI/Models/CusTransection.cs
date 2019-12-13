using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class CusTransection
    {
        public Branch Branch { get; set; }

        [Key]
        public int Id { get; set; }
        [Display(Name = "Enter the user ID of the Customer:")]
        public int CustomerId { get; set; }
        [Required]
        public double Amount { get; set; }
        public int BranchId { get; set; }       //Current Branch ID
        public string  TransDate { get; set; }

    }
}