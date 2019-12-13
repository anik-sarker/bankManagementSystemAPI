using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using bmsAPI.Models;

namespace bmsAPI.Controllers
{
    [RoutePrefix("api/Branches")]
    public class BranchesController : ApiController
    {
        private bmsAPIDbContext db = new bmsAPIDbContext();

        // GET: api/Branches
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = db.Branches.ToList();
            List<Branch> branches = new List<Branch>();
            foreach (var item in list)
            {
                Branch branch = new Branch();
                branch.BranchId = item.BranchId;
                branch.BranchName = item.BranchName;
                branch.CurrentEmployees = item.CurrentEmployees;
                branch.Balance = item.Balance;
                branch.links.Add(new Links() { HRef = "http://localhost:60690/api/branches", Method = "GET", Rel = "Self" });
                branch.links.Add(new Links() { HRef = "http://localhost:60690/api/branches/" + branch.BranchId, Method = "GET", Rel = "Specific Resource" });
                branch.links.Add(new Links() { HRef = "http://localhost:60690/api/branches/" + branch.BranchId, Method = "PUT", Rel = "Resource Edit" });
                branch.links.Add(new Links() { HRef = "http://localhost:60690/api/branches/" + branch.BranchId, Method = "DELETE", Rel = "Resource Delete" });
                branch.links.Add(new Links() { HRef = "http://localhost:60690/api/branches", Method = "POST", Rel = "Resource Create" });
                branches.Add(branch);
            }
            return Ok(branches);
        }

        // GET: api/Branches/5
        [ResponseType(typeof(Branch))]
        [Route("{id}", Name = "GetBranchById")]
        public IHttpActionResult GetById(int id)
        {
            var item = db.Branches.Where(p => p.BranchId == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Branch branch = new Branch();
                branch.BranchId = item.BranchId;
                branch.BranchName = item.BranchName;
                branch.CurrentEmployees = item.CurrentEmployees;
                branch.Balance = item.Balance;
                branch.links.Add(new Links() { HRef = "http://localhost:60690/api/branches", Method = "GET", Rel = "Self" });
                branch.links.Add(new Links() { HRef = "http://localhost:60690/api/branches/" + branch.BranchId, Method = "GET", Rel = "Specific Resource" });
                branch.links.Add(new Links() { HRef = "http://localhost:60690/api/branches/" + branch.BranchId, Method = "PUT", Rel = "Resource Edit" });
                branch.links.Add(new Links() { HRef = "http://localhost:60690/api/branches/" + branch.BranchId, Method = "DELETE", Rel = "Resource Delete" });
                branch.links.Add(new Links() { HRef = "http://localhost:60690/api/branches", Method = "POST", Rel = "Resource Create" });
                return Ok(branch);
            }
        }

        // PUT: api/Branches/5
        [ResponseType(typeof(void))]
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody] Branch branch)
        {
            var item = db.Branches.Where(p => p.BranchId == id).FirstOrDefault();

            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                item.BranchId = id;
                item.BranchName = branch.BranchName;
                item.CurrentEmployees = branch.CurrentEmployees;
                item.Balance = branch.Balance;

                Branch bran = new Branch();
                bran.BranchId = item.BranchId;
                bran.BranchName = item.BranchName;
                bran.CurrentEmployees = item.CurrentEmployees;
                bran.Balance = item.Balance;
                db.SaveChanges();
                return Ok(bran);
            }
        }

        // POST: api/Branches
        [ResponseType(typeof(Branch))]
        [Route("")]
        public IHttpActionResult Post([FromBody] Branch branch)
        {
            db.Branches.Add(branch);
            db.SaveChanges();
            return Created(Url.Link("GetBranchById", new { id = branch.BranchId }), branch);
        }

        // DELETE: api/Branches/5
        [ResponseType(typeof(Branch))]
        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            var item = db.Branches.Where(p => p.BranchId == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                db.Branches.Remove(item);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        // GET: api/Branches/5/Customers
        [Route("{id}/Customers")]
        public IHttpActionResult GetCustomersByBranch([FromUri]int id)
        {
            var list = db.Customers.Where(p => p.BranchId == id);
            if (list.FirstOrDefault() == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                List<Customer> customers = new List<Customer>();
                foreach (var item in list)
                {
                    Customer cust = new Customer();
                    cust.CustomerId = item.CustomerId;
                    cust.Name = item.Name;
                    cust.Email = item.Email;
                    cust.Address = item.Address;
                    cust.CardId = item.CardId;
                    cust.CardStatusId = item.CardStatusId;
                    cust.AccountId = item.AccountId;
                    cust.BranchId = item.BranchId;
                    customers.Add(cust);
                }
                return Ok(customers);
            }
        }

        // GET: api/Branches/5/Customers/3
        [Route("{id}/Customers/{cid}")]
        public IHttpActionResult GetCustomerByBranch(int id, [FromUri]int cid)
        {
            var item = db.Customers.Where(p => p.BranchId == id && p.CustomerId == cid).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Customer cust = new Customer();
                cust.CustomerId = item.CustomerId;
                cust.Name = item.Name;
                cust.Email = item.Email;
                cust.Address = item.Address;
                cust.CardId = item.CardId;
                cust.CardStatusId = item.CardStatusId;
                cust.AccountId = item.AccountId;
                cust.BranchId = item.BranchId;
                return Ok(cust);
            }
        }

        // POST: api/Branches/5/Customers
        [Route("{id}/Customers")]
        public IHttpActionResult Post([FromBody] Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return Created(Url.Link("GetCustomerById", new { id = customer.CustomerId }), customer);
        }

        // PUT: api/Branches/5/Customers/3
        [Route("{id}/Customers/{cid}")]
        public IHttpActionResult Put(int id, [FromUri]int cid, [FromBody] Customer customer)
        {
            var item = db.Customers.Where(p => p.BranchId == id && p.CustomerId == cid).FirstOrDefault();

            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                item.CustomerId = cid;
                item.Name = customer.Name;
                item.Email = customer.Email;
                item.Address = customer.Address;
                item.CardId = customer.CardId;
                item.CardStatusId = customer.CardStatusId;
                item.AccountId = customer.AccountId;
                item.BranchId = customer.BranchId;
                item.Card = null;
                item.CardStatus = null;
                item.Account = null;
                item.Branch = null;


                Customer cust = new Customer();
                cust.CustomerId = item.CustomerId;
                cust.Name = item.Name;
                cust.Email = item.Email;
                cust.Address = item.Address;
                cust.CardId = item.CardId;
                cust.CardStatusId = item.CardStatusId;
                cust.AccountId = item.AccountId;
                cust.BranchId = item.BranchId;
                db.SaveChanges();
                return Ok(cust);
            }
        }

        // DELETE: api/Branches/5/Customers/3
        [Route("{id}/Customers/{cid}")]
        public IHttpActionResult Delete( int id, [FromUri]int cid)
        {
            var item = db.Customers.Where(p => p.BranchId == id && p.CustomerId == cid).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                db.Customers.Remove(item);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}