using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class Customer
    {
        
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CardId { get; set; }
        public int CardStatusId { get; set; }
        public int BranchId { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Card Card { get; set; }
        public virtual CardStatus CardStatus { get; set; }

        public List<Links> links = new List<Links>();
    
    }
}