using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserPasssword { get; set; }
        public string UserRole { get; set; }
    }
}