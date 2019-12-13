using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using bmsAPI.Models;

namespace bmsAPI.Controllers
{
    [RoutePrefix("api/Customers")]
    public class CustomersController : ApiController
    {
        bmsAPIDbContext db = new bmsAPIDbContext();
        [Route("")]
        // GET: api/Customers
        public IHttpActionResult Get()
        {
            var list = db.Customers.ToList();
            List<Customer> customers = new List<Customer>();
            foreach (var item in list)
            {
                Customer customer = new Customer();
                customer.CustomerId = item.CustomerId;
                customer.Name = item.Name;
                customer.Email = item.Email;
                customer.Address = item.Address;
                customer.CardId = item.CardId;
                customer.CardStatusId = item.CardStatusId;
                customer.AccountId = item.AccountId;
                customer.BranchId = item.BranchId;
                customer.links.Add(new Links() { HRef = "http://localhost:60690/api/customers", Method = "GET", Rel = "Self" });
                customer.links.Add(new Links() { HRef = "http://localhost:60690/api/customers/" + customer.CustomerId, Method = "GET", Rel = "Specific Resource" });
                customer.links.Add(new Links() { HRef = "http://localhost:60690/api/customers/" + customer.CustomerId, Method = "PUT", Rel = "Resource Edit" });
                customer.links.Add(new Links() { HRef = "http://localhost:60690/api/customers/" + customer.CustomerId, Method = "DELETE", Rel = "Resource Delete" });
                customer.links.Add(new Links() { HRef = "http://localhost:60690/api/customers", Method = "POST", Rel = "Resource Create" });
                customers.Add(customer);
            }
            return Ok(customers);
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        [Route("{id}", Name = "GetCustomerById")]
        public IHttpActionResult GetById(int id)
        {
            var item = db.Customers.Where(p => p.CustomerId == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Customer customer = new Customer();
                customer.CustomerId = item.CustomerId;
                customer.Name = item.Name;
                customer.Email = item.Email;
                customer.Address = item.Address;
                customer.CardId = item.CardId;
                customer.CardStatusId = item.CardStatusId;
                customer.AccountId = item.AccountId;
                customer.BranchId = item.BranchId;
                customer.links.Add(new Links() { HRef = "http://localhost:60690/api/customers", Method = "GET", Rel = "Self" });
                customer.links.Add(new Links() { HRef = "http://localhost:60690/api/customers/" + customer.CustomerId, Method = "GET", Rel = "Specific Resource" });
                customer.links.Add(new Links() { HRef = "http://localhost:60690/api/customers/" + customer.CustomerId, Method = "PUT", Rel = "Resource Edit" });
                customer.links.Add(new Links() { HRef = "http://localhost:60690/api/customers/" + customer.CustomerId, Method = "DELETE", Rel = "Resource Delete" });
                customer.links.Add(new Links() { HRef = "http://localhost:60690/api/customers", Method = "POST", Rel = "Resource Create" });
                return Ok(customer);
            }
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody] Customer customer)
        {
            var item = db.Customers.Where(p => p.CustomerId == id).FirstOrDefault();

            if(item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                item.CustomerId = id;
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

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        [Route("")]
        public IHttpActionResult Post([FromBody] Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return Created(Url.Link("GetCustomerById", new { id = customer.CustomerId }), customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            var item = db.Customers.Where(p => p.CustomerId == id).FirstOrDefault();
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