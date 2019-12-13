using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class Account
    {
        public Account()
        {
            this.Customers = new HashSet<Customer>();
        }
        public int AccountId { get; set; }
        public string Type { get; set; }

        public List<Links> links = new List<Links>();
        public virtual ICollection<Customer> Customers { get; set; }
    }
}