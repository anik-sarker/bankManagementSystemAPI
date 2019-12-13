using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class Branch
    {
        public Branch()
        {
            this.Customers = new HashSet<Customer>();
        }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int CurrentEmployees { get; set; }
        public double Balance { get; set; }

        public List<Links> links = new List<Links>();
        public virtual ICollection<Customer> Customers { get; set; }
    }
}