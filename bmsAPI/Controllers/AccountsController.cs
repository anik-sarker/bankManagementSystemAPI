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
    [RoutePrefix("api/Accounts")]
    public class AccountsController : ApiController
    {
        private bmsAPIDbContext db = new bmsAPIDbContext();

        // GET: api/Accounts
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = db.Accounts.ToList();
            List<Account> accounts = new List<Account>();
            foreach (var item in list)
            {
                Account account = new Account();
                account.AccountId = item.AccountId;
                account.Type = item.Type;
                account.links.Add(new Links() { HRef = "http://localhost:60690/api/accounts", Method = "GET", Rel = "Self" });
                account.links.Add(new Links() { HRef = "http://localhost:60690/api/accounts/" + account.AccountId, Method = "GET", Rel = "Specific Resource" });
                account.links.Add(new Links() { HRef = "http://localhost:60690/api/accounts/" + account.AccountId, Method = "PUT", Rel = "Resource Edit" });
                account.links.Add(new Links() { HRef = "http://localhost:60690/api/accounts/" + account.AccountId, Method = "DELETE", Rel = "Resource Delete" });
                account.links.Add(new Links() { HRef = "http://localhost:60690/api/accounts", Method = "POST", Rel = "Resource Create" });
                accounts.Add(account);
            }
            return Ok(accounts);
        }

        // GET: api/Accounts/5
        [ResponseType(typeof(Account))]
        [Route("{id}", Name = "GetAccountById")]
        public IHttpActionResult GetById(int id)
        {
            var item = db.Accounts.Where(p => p.AccountId == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Account account = new Account();
                account.AccountId = item.AccountId;
                account.Type = item.Type;
                account.links.Add(new Links() { HRef = "http://localhost:60690/api/accounts", Method = "GET", Rel = "Self" });
                account.links.Add(new Links() { HRef = "http://localhost:60690/api/accounts/" + account.AccountId, Method = "GET", Rel = "Specific Resource" });
                account.links.Add(new Links() { HRef = "http://localhost:60690/api/accounts/" + account.AccountId, Method = "PUT", Rel = "Resource Edit" });
                account.links.Add(new Links() { HRef = "http://localhost:60690/api/accounts/" + account.AccountId, Method = "DELETE", Rel = "Resource Delete" });
                account.links.Add(new Links() { HRef = "http://localhost:60690/api/accounts", Method = "POST", Rel = "Resource Create" });
                return Ok(account);
            }
        }

        // PUT: api/Accounts/5
        [ResponseType(typeof(void))]
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody] Account account)
        {
            var item = db.Accounts.Where(p => p.AccountId == id).FirstOrDefault();

            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                item.AccountId = id;
                item.Type = account.Type;

                Account acc = new Account();
                acc.AccountId = item.AccountId;
                acc.Type = item.Type;
                db.SaveChanges();
                return Ok(acc);
            }
        }

        // POST: api/Accounts
        [ResponseType(typeof(Account))]
        [Route("")]
        public IHttpActionResult Post([FromBody] Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return Created(Url.Link("GetAccountById", new { id = account.AccountId }), account);
        }

        // DELETE: api/Accounts/5
        [ResponseType(typeof(Account))]
        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            var item = db.Accounts.Where(p => p.AccountId == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                db.Accounts.Remove(item);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        //GET: api/Accounts/5/Customers
        [Route("{id}/Customers")]
        public IHttpActionResult GetCustomersByAccount([FromUri]int id)
        {
            var list = db.Customers.Where(p => p.AccountId == id);
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

        // GET: api/Accounts/5/Customers/3
        [Route("{id}/Customers/{cid}")]
        public IHttpActionResult GetCustomerByAccount(int id, [FromUri]int cid)
        {
            var item = db.Customers.Where(p => p.AccountId == id && p.CustomerId == cid).FirstOrDefault();
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

        // POST: api/Accounts/5/Customers
        [Route("{id}/Customers")]
        public IHttpActionResult Post([FromBody] Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return Created(Url.Link("GetCustomerById", new { id = customer.CustomerId }), customer);
        }

        // PUT: api/Accounts/5/Customers/3
        [Route("{id}/Customers/{cid}")]
        public IHttpActionResult Put(int id, [FromUri]int cid, [FromBody] Customer customer)
        {
            var item = db.Customers.Where(p => p.AccountId == id && p.CustomerId == cid).FirstOrDefault();

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

        // DELETE: api/Accounts/5/Customers/3
        [Route("{id}/Customers/{cid}")]
        public IHttpActionResult Delete(int id, [FromUri]int cid)
        {
            var item = db.Customers.Where(p => p.AccountId == id && p.CustomerId == cid).FirstOrDefault();
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