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
    public class ManagersController : ApiController
    {
        private bmsAPIDbContext db = new bmsAPIDbContext();

        [Route("api/Managers")]
        // GET: api/Managers
        public IHttpActionResult GetManagers()
        {
            var list = db.Managers.ToList();
            List<Manager> man = new List<Manager>();
            foreach (var item in list)
            {
                Manager manager = new Manager();
                manager.Id = item.Id;
                manager.Salary = item.Salary;
                manager.BranchId = item.BranchId;
                manager.DateOfBirth = item.DateOfBirth;
                manager.Email = item.Email;
                manager.Gender = item.Gender;
                manager.JoinDate = item.JoinDate;
                manager.ManPoints = item.ManPoints;
                manager.NID = item.NID;
                manager.Name = item.Name;
                manager.Password = item.Password;
                manager.PhoneNumber = item.PhoneNumber;

                manager.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers", Method = "GET", Rel = "Self" });
                manager.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manager.Id, Method = "GET", Rel = "Specific Resource" });
                manager.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manager.Id, Method = "PUT", Rel = "Resource Edit" });
                manager.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manager.Id, Method = "DELETE", Rel = "Resource Delete" });
                manager.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers", Method = "POST", Rel = "Resource Create" });
                man.Add(manager);
            }
            return Ok(man);
        }
        // GET: api/Managers/5
        [ResponseType(typeof(Manager))]
        public IHttpActionResult GetManager(int id)
        {
            Manager item = db.Managers.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                Manager manager = new Manager();
                manager.Id = item.Id;
                manager.Salary = item.Salary;
                manager.BranchId = item.BranchId;
                manager.DateOfBirth = item.DateOfBirth;
                manager.Email = item.Email;
                manager.Gender = item.Gender;
                manager.JoinDate = item.JoinDate;
                manager.ManPoints = item.ManPoints;
                manager.NID = item.NID;
                manager.Name = item.Name;
                manager.Password = item.Password;
                manager.PhoneNumber = item.PhoneNumber;

                manager.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers", Method = "GET", Rel = "Self" });
                manager.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manager.Id, Method = "GET", Rel = "Specific Resource" });
                manager.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manager.Id, Method = "PUT", Rel = "Resource Edit" });
                manager.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers/" + manager.Id, Method = "DELETE", Rel = "Resource Delete" });
                manager.links.Add(new Links() { HRef = "http://localhost:17193/api/Managers", Method = "POST", Rel = "Resource Create" });
                return Ok(manager);
            }
        }

        // PUT: api/Managers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutManager(int id, Manager manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manager.Id)
            {
                return BadRequest();
            }

            db.Entry(manager).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Managers
        [ResponseType(typeof(Manager))]
        public IHttpActionResult PostManager(Manager manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Managers.Add(manager);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = manager.Id }, manager);
        }

        // DELETE: api/Managers/5
        [ResponseType(typeof(Manager))]
        public IHttpActionResult DeleteManager(int id)
        {
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return NotFound();
            }

            db.Managers.Remove(manager);
            db.SaveChanges();

            return Ok(manager);
        }

        [System.Web.Http.Route("api/Managers/{manid}/Transection")]         //GEt transection by manager id
        public IHttpActionResult GetManagersAllTansection(int manid)
        {
            List<MangrTransection> mt = db.MangrTransections.Where(c=>c.ManagerId == manid).ToList();
            if (mt.Count == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(mt);
            }
            
        }

        [Route("api/Managers/{manid}/Transection/{tid}")]         //GEt transection by manager id
        public IHttpActionResult GetManagersTansectionbyByManidAndTranid (int manid,int tid)
        {
            var mt = db.MangrTransections.Where(c=>c.ManagerId == manid && c.Id == tid).FirstOrDefault();
            if (mt== null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(mt);
            }

        }

        [HttpPost]
        [Route("api/Managers/{mid}/Transection")]        // create a transection for manager
        public IHttpActionResult PostTransection(int mid, MangrTransection tran)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tran.ManagerId = mid;
            db.MangrTransections.Add(tran);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tran.Id }, tran);
        }

        [Route("api/Managers/{mid}/Transection/{tid}")]     // PUT manger transection by transection id
        public IHttpActionResult PutTransectionByManager(int mid, int tid, MangrTransection tran)
        {
            var mt = db.MangrTransections.Where(c=>c.Id == tid && c.ManagerId == mid).FirstOrDefault();
            if (mt == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                mt.Id = tid;
                mt.ManagerId = mid;
                mt.Amount = tran.Amount;
                mt.Authorized = tran.Authorized;
                mt.BranchId = tran.BranchId;
                mt.TransDate = DateTime.Now.ToLongDateString();
                mt.Branch = tran.Branch;

                db.SaveChanges();
                return Ok(mt);

            }
        }
        


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManagerExists(int id)
        {
            return db.Managers.Count(e => e.Id == id) > 0;
        }
    }
}