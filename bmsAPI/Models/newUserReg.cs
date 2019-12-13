using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class NewUserReg
    {
        public UserType UserType { get; set; }
        [Key]
        public int Id { get; set; }

        public int UserTypeId { get; set; }
    }
}