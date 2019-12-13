using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class CusAccountType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AccType { get; set; }
        [Required]
        public int MaxTransection { get; set; }
    }
}