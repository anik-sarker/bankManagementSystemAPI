using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class CardStatus
    {
        public CardStatus()
        {
            this.Customers = new HashSet<Customer>();
        }
        public int CardStatusId { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}