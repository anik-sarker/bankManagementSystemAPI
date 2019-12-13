using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class BankBalance
    {
        [Key]
        public int Id { get; set; }
        
        //balance money will be added when an transection is occur between customers , at cash out and from loan interest
        public double Balance { get; set; }
    }
}