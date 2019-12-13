using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class Card
    {
        public Card()
        {
            this.Customers = new HashSet<Customer>();
        }
        public int CardId { get; set; }
        public string CardType { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}